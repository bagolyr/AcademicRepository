using System.ComponentModel.DataAnnotations;

namespace _2022_09_23.Attributes
{
    // Task 27: Készítsen custom modell validációs attribútumot a Neptun kódhoz.A Neptun kód pontosan 6
    // karakterből áll, csak számokat vagy betűket tartalmazhat, és nem kezdődhet számmal
    public class NeptunCodeValidationAttribute : ValidationAttribute
    {
        private readonly static int NEPTUN_CODE_LENGTH = 6;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string neptunCode)
            {
                IList<int> numbers = new List<int>();
                string formattedNeptunCode = new string(neptunCode.Where(c => char.IsDigit(c)).ToArray());
                //Check neptun code length
                if (formattedNeptunCode.Length != NEPTUN_CODE_LENGTH)
                {
                    return new ValidationResult("Neptun code should contain " + NEPTUN_CODE_LENGTH + " character!");
                }
                int ok_counter = 0;
                for (int i = 0; i < formattedNeptunCode.Length - 1; i++)
                {
                    if ((i == 0) // idx[0] shall not be a number
                        && (formattedNeptunCode[0] >= '0' && formattedNeptunCode[0] <= '9')
                    )
                    {
                        return new ValidationResult("Neptun code is not allowed to start with a number!");
                    }
                    else if ((i == 0) // idx[0] shall be a char between a-z or A-Z
                        && ((formattedNeptunCode[0] >= 'a' && formattedNeptunCode[0] <= 'z') ||
                            (formattedNeptunCode[0] >= 'A' && formattedNeptunCode[0] <= 'Z')
                        )
                    )
                    {
                        ok_counter++;
                    }
                    else
                    {
                        if ((formattedNeptunCode[0] >= '0' && formattedNeptunCode[0] <= '9') ||
                            (formattedNeptunCode[0] >= 'a' && formattedNeptunCode[0] <= 'z') ||
                            (formattedNeptunCode[0] >= 'A' && formattedNeptunCode[0] <= 'Z')
                        )
                        {
                            ok_counter++;
                        }
                    }
                }

                if (ok_counter == NEPTUN_CODE_LENGTH) // if all indexes are marked as OK
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Wrong Neptun code!");
            }

            return new ValidationResult("Wrong Neptun code!");
        }
    }
}
