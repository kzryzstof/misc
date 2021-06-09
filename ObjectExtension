using FluentAssertions;
using Moq;

namespace NoSuchCompany.QualityTools.Moq
{
    #region Class

    public static class ObjectExtension
    {
        #region Public Methods

        public static TObjectType OrEquivalent<TObjectType>(this TObjectType expectedInstance)
        {
            return It.Is<TObjectType>(actualInstance => IsEquivalent(expectedInstance, actualInstance));
        }

        #endregion

        #region Private Methods

        private static bool IsEquivalent<TObjectType>(TObjectType expectedInstance, TObjectType actualInstance)
        {
            try
            {
                actualInstance.Should().BeEquivalentTo(expectedInstance);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }

    #endregion
}
