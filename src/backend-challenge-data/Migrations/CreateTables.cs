using FluentMigrator;
using System;

namespace backend_challenge_data.Migrations
{
    [Migration(20210707000002)]
    public class CreateTables
        : Migration
    {
        public override void Up()
        {
            /*
Id
CreatedAt
UpdatedAt
Deleted             
             */

            //Person
            Create
                .Table("Person")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable().WithDefaultValue(DateTimeOffset.Now)
                .WithColumn("Deleted").AsBoolean().NotNullable().WithDefaultValue(false);

            /*
                .WithColumn("Pwd").AsString(Constants.DEFAULT_FIELD_LENGTH_PWD).NotNullable()
                .WithColumn("Salt").AsString(Constants.DEFAULT_FIELD_LENGTH_PWD_SALT).NotNullable()
                .WithColumn("Blocked").AsBoolean().NotNullable().WithDefaultValue(true);
                */


            Insert
                .IntoTable("Person")
                .Row(new User { Id = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), Email = "carlos.vernizze@outlook.com", Login = "vernizze", Pwd = pwdHash, Salt = salt, Confirmed = true, Blocked = false });

            //Insert
            //    .IntoTable("User")
            //    .Row(new User { Id = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), Email = "carlos.vernizze2@outlook.com", Login = "vernizze2", Pwd = pwdHash, Salt = salt, Confirmed = true, Blocked = false });

            //Claim
            Create
                .Table("Claim")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("UserCreatorId").AsGuid().ForeignKey("FK_Claim_User", "User", "Id").NotNullable().Indexed()
                .WithColumn("Description").AsString(Constants.DEFAULT_FIELD_LENGTH_DESCRIPTION).NotNullable();

            Insert
                .IntoTable("Claim")
                .Row(new Claim { Id = new Guid("178b11d6-dc65-468c-bd63-4a647d067821"), Description = "Read", UserCreatorId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f") })
                .Row(new Claim { Id = new Guid("43c3ec70-4a09-44fe-b81f-f405f90accb2"), Description = "Write", UserCreatorId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f") })
                .Row(new Claim { Id = new Guid("dbd4dff2-1cc5-480c-8a12-e74a0f0fffa1"), Description = "Update", UserCreatorId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f") })
                .Row(new Claim { Id = new Guid("6559d1b6-d1fc-48ab-bf75-2d3cfce700d3"), Description = "Delete", UserCreatorId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f") });

            Insert
                .IntoTable("Claim")
                .Row(new Claim { Id = new Guid("bb035a22-a9db-464d-8809-96a3406e2988"), Description = "Read2", UserCreatorId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879") });

            //UserClaim
            Create
                .Table("UserClaim")
                .WithColumn("UserId").AsGuid().ForeignKey("FK_UserClaim_User", "User", "Id").PrimaryKey()
                .WithColumn("ClaimUserOwnerId").AsGuid().ForeignKey("FK_UserClaim_UserOwner", "User", "Id").PrimaryKey()
                .WithColumn("ClaimId").AsGuid().ForeignKey("FK_UserClaim_Claim", "Claim", "Id").PrimaryKey();

            Insert
                .IntoTable("UserClaim")
                .Row(new UserClaim { UserId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("178b11d6-dc65-468c-bd63-4a647d067821") })
                .Row(new UserClaim { UserId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("43c3ec70-4a09-44fe-b81f-f405f90accb2") })
                .Row(new UserClaim { UserId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("dbd4dff2-1cc5-480c-8a12-e74a0f0fffa1") })
                .Row(new UserClaim { UserId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("6559d1b6-d1fc-48ab-bf75-2d3cfce700d3") });

            Insert
                .IntoTable("UserClaim")
                .Row(new UserClaim { UserId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), ClaimUserOwnerId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), ClaimId = new Guid("bb035a22-a9db-464d-8809-96a3406e2988") })
                .Row(new UserClaim { UserId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("178b11d6-dc65-468c-bd63-4a647d067821") })
                .Row(new UserClaim { UserId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("43c3ec70-4a09-44fe-b81f-f405f90accb2") })
                .Row(new UserClaim { UserId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("dbd4dff2-1cc5-480c-8a12-e74a0f0fffa1") })
                .Row(new UserClaim { UserId = new Guid("610eb12a-7ee8-40ef-862a-4ba11fe91879"), ClaimUserOwnerId = new Guid("ba18f005-e6a6-4ee0-b8b0-6f00e9477c7f"), ClaimId = new Guid("6559d1b6-d1fc-48ab-bf75-2d3cfce700d3") });
        }

        public override void Down()
        {
            Delete.Table("User");
            Delete.Table("Claim");
            Delete.Table("UserClaim");
        }
    }
