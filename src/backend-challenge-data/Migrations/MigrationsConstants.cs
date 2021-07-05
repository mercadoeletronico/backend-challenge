namespace backend_challenge_data.Migrations
{
    public class MigrationsConstants
    {
        public const int NaturalPerson_Field_Length_Cpf = 11;
        public const int NaturalPerson_Field_Length_Name = 100;

        public const int LegalPerson_Field_Length_Cnpj = 14;
        public const int LegalPerson_Field_Length_LegalName = 100;

        public const int Pherson_Field_Length_Ddi = 4;
        public const int Pherson_Field_Length_Ddd = 4;
        public const int Pherson_Field_Length_Number = 9;

        public const int Email_Field_Length_Address = 100;

        public const int Address_Field_Length_ZipCode = 15;
        public const int Address_Field_Length_Street = 150;
        public const int Address_Field_Length_Number = 4;
        public const int Address_Field_Length_City = 75;
        public const int Address_Field_Length_State = 2;
        public const int Address_Field_Length_Country = 2;

        public const int Customer_Field_Length_Code = 15;

        public const int Seller_Field_Length_Code = 15;

        public const int Product_Field_Length_ReferenceCode = 15;
        public const int Product_Field_Length_Description = 50;

        public const int Order_Field_Length_Number = 20;
    }
}
