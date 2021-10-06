using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace XFConsole.Blazored
{
    [SuppressMessage("Usage", "BL0006:Do not use RenderTree types", Justification = "<Pending>")]
    public class ContainerComponent : IComponent
    {
        private readonly TestRenderer _renderer;
        private RenderHandle _renderHandle;
        private int _componentId;

        public ContainerComponent(TestRenderer renderer)
        {
            _renderer = renderer;
            _componentId = renderer.AttachTestRootComponent(this);
        }

        public void Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            throw new NotImplementedException($"{nameof(ContainerComponent)} shouldn't receive any parameters");
        }

        public (int, object) FindComponentUnderTest()
        {
            var ownFrames = _renderer.GetCurrentRenderTreeFrames(_componentId);
            if (ownFrames.Count == 0)
            {
                throw new InvalidOperationException($"{nameof(ContainerComponent)} hasn't yet rendered");
            }

            ref var childComponentFrame = ref ownFrames.Array[0];
            Debug.Assert(childComponentFrame.FrameType == RenderTreeFrameType.Component);
            Debug.Assert(childComponentFrame.Component != null);
            return (childComponentFrame.ComponentId, childComponentFrame.Component);
        }

        public void RenderComponentUnderTest(Type componentType, ParameterView parameters)
        {
            _renderer.DispatchAndAssertNoSynchronousErrors(() =>
            {
                _renderHandle.Render(builder =>
                {
                    builder.OpenComponent(0, componentType);

                    foreach (var parameterValue in parameters)
                    {
                        builder.AddAttribute(1, parameterValue.Name, parameterValue.Value);
                    }

                    builder.CloseComponent();
                });
            });
        }
    }
}
