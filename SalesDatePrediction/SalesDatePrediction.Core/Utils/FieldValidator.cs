using SalesDatePrediction.Core.Exceptions;

namespace SalesDatePrediction.Core.Utils
{
    public static class FieldValidator
    {
        public static void ValidateRequiredFields(object field)
        {
            if (field is null)
            {
                throw new BadRequestException("Missing required fields");
            }
        }
    }
}
