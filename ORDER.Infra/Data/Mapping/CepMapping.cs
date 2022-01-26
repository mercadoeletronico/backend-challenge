// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace ORDER.Infra.Data.Mapping
// {
//     public static class CepMapping
//     {
//         public static void MappingCep(this EntityTypeBuilder<Cep> entity)
//         {
//             entity.HasKey(x => x.Id)
//                 .HasName("PK_CEP");
//             
//             entity.ToTable("CEP");
//
//             entity.Property(x => x.Id)
//                 .UseIdentityColumn();
//
//             entity.Property(x => x.Code)
//                 .HasMaxLength(9)
//                 .IsRequired();
//             
//             entity.Property(x => x.Logradouro)
//                 .HasMaxLength(500)
//                 .IsRequired();
//             
//             entity.Property(x => x.Complemento)
//                 .HasMaxLength(500)
//                 .IsRequired();
//             
//             entity.Property(x => x.Bairro)
//                 .HasMaxLength(500)
//                 .IsRequired();
//             
//             entity.Property(x => x.Localidade)
//                 .HasMaxLength(500)
//                 .IsRequired();
//             
//             entity.Property(x => x.Uf)
//                 .HasMaxLength(2)
//                 .IsRequired();
//             
//             entity.Property(x => x.Ibge)
//                 .IsRequired();
//             
//             entity.Property(x => x.Gia)
//                 .HasMaxLength(500)
//                 .IsRequired();
//             
//             entity.Property(x => x.Ddd)
//                 .HasMaxLength(500)
//                 .IsRequired();
//             
//             entity.Property(x => x.Siafi)
//                 .HasMaxLength(500)
//                 .IsRequired();
//         }
//     }
// }