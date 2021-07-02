using backend_challenge_domain_datatypes.Entities;
using FluentMigrator;
using System;
using Vrnz2.Infra.CrossCutting.Types;

namespace backend_challenge_data.Migrations
{
    [Migration(20210707000001)]
    public class CreateDatabase
        : Migration
    {
        public override void Up()
        {
            //Person
            var customerPersonId = Guid.NewGuid();
            var seller01PersonId = Guid.NewGuid();
            var seller02PersonId = Guid.NewGuid();
            Create
                .Table("Person")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable();

            Insert
                .IntoTable("Person")
                .Row(new Person { Id = customerPersonId, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false })
                .Row(new Person { Id = seller01PersonId, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false })
                .Row(new Person { Id = seller02PersonId, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false });
            

            //NaturalPerson
            Cpf customerCpf = "308.929.540-78";
            Create
                .Table("NaturalPerson")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_NaturalPerson_Person", "Person", "Id").NotNullable()
                .WithColumn("Cpf").AsString(Constants.NaturalPerson_Field_Length_Cpf).NotNullable()
                .WithColumn("Name").AsString(Constants.NaturalPerson_Field_Length_Name).NotNullable();

            Insert
                .IntoTable("NaturalPerson")
                .Row(new NaturalPerson { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, Cpf = customerCpf.NumericValue.ToString(), Name = "José da Silva" });


            //JuridicalPerson
            Cnpj seller01Cnpj = "26.070.359/0001-29";
            Cnpj seller02Cnpj = "85.980.128/0001-11";
            Create
                .Table("JuridicalPerson")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_JuridicalPerson_Person", "Person", "Id").NotNullable()
                .WithColumn("Cnpj").AsString(Constants.LegalPerson_Field_Length_Cnpj).NotNullable()
                .WithColumn("LegalName").AsString(Constants.LegalPerson_Field_Length_LegalName).NotNullable();

            Insert
                .IntoTable("JuridicalPerson")
                .Row(new JuridicalPerson { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, Cnpj = seller01Cnpj.NumericValue.ToString(), LegalName = "Giz de Cera Co." })
                .Row(new JuridicalPerson { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, Cnpj = seller02Cnpj.NumericValue.ToString(), LegalName = "Papelaria da Lucia Ltda." });


            //Phone
            Create
                .Table("Phone")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_Phone_Person", "Person", "Id").NotNullable()
                .WithColumn("Ddi").AsString(Constants.Pherson_Field_Length_Ddi).NotNullable()
                .WithColumn("Ddd").AsString(Constants.Pherson_Field_Length_Ddd).NotNullable()
                .WithColumn("Number").AsString(Constants.Pherson_Field_Length_Number).NotNullable();

            Insert
                .IntoTable("Phone")
                .Row(new Phone { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, Ddi = "55", Ddd = "41", Number = "42751884" })
                .Row(new Phone { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, Ddi = "55", Ddd = "41", Number = "35871234" })
                .Row(new Phone { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, Ddi = "55", Ddd = "41", Number = "39887855" });


            //Email
            Create
                .Table("Email")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_Email_Person", "Person", "Id").NotNullable()
                .WithColumn("Address").AsString(Constants.Email_Field_Length_Address).NotNullable();

            Insert
                .IntoTable("Email")
                .Row(new Email { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, Address = "jose.silva@internet.com" })
                .Row(new Email { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, Address = "comercial@gizdecera.co" })
                .Row(new Email { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, Address = "vendas@papelariadalucia.com.br" });


            //Address
            Create
                .Table("Address")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_Address_Person", "Person", "Id").NotNullable()
                .WithColumn("ZipCode").AsString(Constants.Address_Field_Length_ZipCode).NotNullable()
                .WithColumn("Street").AsString(Constants.Address_Field_Length_Street).NotNullable()
                .WithColumn("Number").AsString(Constants.Address_Field_Length_Number).NotNullable()
                .WithColumn("City").AsString(Constants.Address_Field_Length_City).NotNullable()
                .WithColumn("State").AsString(Constants.Address_Field_Length_State).NotNullable()
                .WithColumn("Country").AsString(Constants.Address_Field_Length_Country).NotNullable()
                ;

            Insert
                .IntoTable("Address")                                                                                                                                                  
                .Row(new Address { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, ZipCode = "83.000-100", Street = "Rua XV de Novembro", Number = "10", City = "Curitiba", State = "PR", Country = "BR" })
                .Row(new Address { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, ZipCode = "83.000-200", Street = "Av Marechal Deodoro", Number = "20", City = "Curitiba", State = "PR", Country = "BR" })
                .Row(new Address { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, ZipCode = "83.000-300", Street = "Av Sete de Setembro", Number = "30", City = "Curitiba", State = "PR", Country = "BR" });


            //Customer
            Create
                .Table("Customer")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_Customer_Person", "Person", "Id").NotNullable()
                .WithColumn("Code").AsString(Constants.Customer_Field_Length_Code).NotNullable();

            Insert
                .IntoTable("Customer")
                .Row(new Customer { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, Code = "CUST00001" });


            //Seller
            Create
                .Table("Seller")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_Seller_Person", "Person", "Id").NotNullable()
                .WithColumn("Code").AsString(Constants.Seller_Field_Length_Code).NotNullable();

            Insert
                .IntoTable("Seller")
                .Row(new Seller { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, Code = "SEL00001" })
                .Row(new Seller { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, Code = "SEL00002" });


            //Product
            var customerProduct01Id = Guid.NewGuid();
            var customerProduct02Id = Guid.NewGuid();

            var seller01Product01Id = Guid.NewGuid();
            var seller01Product02Id = Guid.NewGuid();
            var seller01Product03Id = Guid.NewGuid();
            var seller01Product04Id = Guid.NewGuid();
            var seller01Product05Id = Guid.NewGuid();

            var seller02Product01Id = Guid.NewGuid();
            var seller02Product02Id = Guid.NewGuid();
            var seller02Product03Id = Guid.NewGuid();
            var seller02Product04Id = Guid.NewGuid();
            var seller02Product05Id = Guid.NewGuid();
            Create
                .Table("Product")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("PersonId").AsGuid().ForeignKey("FK_Seller_Person", "Person", "Id").NotNullable()
                .WithColumn("ReferenceCode").AsString(Constants.Product_Field_Length_ReferenceCode).NotNullable().Indexed()
                .WithColumn("Description").AsString(Constants.Product_Field_Length_Description).NotNullable()
                .WithColumn("UnitaryValue").AsCurrency().NotNullable();

            Insert
                .IntoTable("Product")
                .Row(new Product { Id = customerProduct01Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, ReferenceCode = "LCVRD", Description = "Lápis Cera Verde", UnitaryValue = 0M })
                .Row(new Product { Id = customerProduct02Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = customerPersonId, ReferenceCode = "LCBRC", Description = "Lápis Cera Branco", UnitaryValue = 0M })

                .Row(new Product { Id = seller01Product01Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, ReferenceCode = "GC001", Description = "Giz de Cera Verde", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller01Product02Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, ReferenceCode = "GC002", Description = "Giz de Cera Branco", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller01Product03Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, ReferenceCode = "GC003", Description = "Giz de Cera Azul", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller01Product04Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, ReferenceCode = "GC004", Description = "Giz de Cera Amarelo", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller01Product05Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller01PersonId, ReferenceCode = "GC005", Description = "Giz de Cera Preto", UnitaryValue = 1.7M })

                .Row(new Product { Id = seller02Product01Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, ReferenceCode = "LC001", Description = "Lápis de Cera Verde", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller02Product02Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, ReferenceCode = "LC002", Description = "Lápis de Cera Branco", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller02Product03Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, ReferenceCode = "LC003", Description = "Lápis de Cera Azul", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller02Product04Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, ReferenceCode = "LC004", Description = "Lápis de Cera Amarelo", UnitaryValue = 1.5M })
                .Row(new Product { Id = seller02Product05Id, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, PersonId = seller02PersonId, ReferenceCode = "LC005", Description = "Lápis de Cera Preto", UnitaryValue = 1.7M });


            //EquivalentProduct
            Create
                .Table("EquivalentProduct")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("CustomerProductId").AsGuid().ForeignKey("FK_EquivalentProduct_CustomerProduct", "Product", "Id").NotNullable()
                .WithColumn("SellerProductId").AsGuid().ForeignKey("FK_EquivalentProduct_SellerProduct", "Product", "Id").NotNullable();

            Insert
                .IntoTable("EquivalentProduct")
                .Row(new EquivalentProduct { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, CustomerProductId = customerProduct01Id, SellerProductId = seller01Product01Id })
                .Row(new EquivalentProduct { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, CustomerProductId = customerProduct01Id, SellerProductId = seller02Product01Id })
                .Row(new EquivalentProduct { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, CustomerProductId = customerProduct02Id, SellerProductId = seller01Product02Id })
                .Row(new EquivalentProduct { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now, Deleted = false, CustomerProductId = customerProduct02Id, SellerProductId = seller02Product02Id });


            //Order
            Create
                .Table("Order")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("Number").AsString(Constants.Order_Field_Length_Number).NotNullable()
                .WithColumn("CustomerId").AsGuid().ForeignKey("FK_Order_Customer", "Customer", "Id").NotNullable()
                .WithColumn("SellerId").AsGuid().ForeignKey("FK_Order_Seller", "Seller", "Id").NotNullable();


            //OrderItem
            Create
                .Table("OrderItem")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("OrderId").AsGuid().ForeignKey("FK_OrderItem_Order", "Order", "Id").NotNullable()
                .WithColumn("ProductId").AsGuid().ForeignKey("FK_OrderItem_Product", "Product", "Id").NotNullable()
                .WithColumn("Quantity").AsInt64().NotNullable()
                .WithColumn("UnitaryValue").AsCurrency().NotNullable();


            //OrderItemApproval
            Create
                .Table("OrderItemApproval")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable()
                .WithColumn("OrderItemId").AsGuid().ForeignKey("FK_OrderItemApproval_Order", "OrderItem", "Id").NotNullable()
                .WithColumn("Quantity").AsInt64().NotNullable()
                .WithColumn("UnitaryValue").AsCurrency().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Person");
            Delete.Table("NaturalPerson");
            Delete.Table("JuridicalPerson");
            Delete.Table("Phone");
            Delete.Table("Email");
            Delete.Table("Address");
            Delete.Table("Customer");
            Delete.Table("Seller");
            Delete.Table("Product");
            Delete.Table("EquivalentProduct");
            Delete.Table("Order");
            Delete.Table("OrderItem");
            Delete.Table("OrderItemApproval");
        }
    }
}
