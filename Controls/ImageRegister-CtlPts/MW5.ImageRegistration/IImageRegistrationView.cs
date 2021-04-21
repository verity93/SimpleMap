using System;

namespace ImageRegistration.Views.Abstract
{
    interface IImageRegistrationView : IComplexView<ImageRegistrationModel>
    {
        void AddSourceImage(IImageSource image);

        void RemoveTransformedImage();

        void LoadTransformedImage();

        event Action RecalculationNeeded;
    }
}
