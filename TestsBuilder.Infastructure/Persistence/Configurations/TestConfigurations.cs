using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Host.ValueObjects;
using TestsBuilder.Domain.Test;
using TestsBuilder.Domain.Test.Entities;
using TestsBuilder.Domain.Test.ValueObjects;

namespace TestsBuilder.Infastructure.Persistence.Configurations
{
    public class TestConfigurations : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            ConfigureTestsTable(builder);
            ConfigureTestExamplesTable(builder);
        }

        private void ConfigureTestsTable(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("Tests");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => TestId.Create(value));

            builder.Property(t => t.Name)
                .HasMaxLength(100);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            builder.Property(t => t.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));
        }

        private void ConfigureTestExamplesTable(EntityTypeBuilder<Test> builder)
        {
            builder.OwnsMany(t => t.Examples, eb =>
            {
                eb.ToTable("Examples");

                eb.WithOwner()
                    .HasForeignKey("TestId");

                eb.HasKey("Id", "TestId");

                eb.Property(e => e.Id)
                    .HasColumnName("ExampleId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ExampleId.Create(value));

                eb.Property(e => e.Name)
                    .HasMaxLength(100);

                eb.Property(e => e.Text)
                    .HasMaxLength(100);

                eb.Property<List<string>>("BaseAnswers") // Добавляем свойство BaseAnswers
                    .HasColumnName("BaseAnswers");

                eb.OwnsMany(
                    s => s.Variants,
                    vb => ConfigureExampleVariantsTable(vb));

                eb
                    .Navigation(s => s.Variants).Metadata
                    .SetField("_variants");
            });

            builder.Metadata
                .FindNavigation(nameof(Test.Examples))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureExampleVariantsTable(OwnedNavigationBuilder<Example, ExampleVariant> vb)
        {
            vb.ToTable("ExampleVariants");

            vb.WithOwner().HasForeignKey("ExampleId", "TestId");

            vb.HasKey(nameof(ExampleVariant.Id), "ExampleId", "TestId");

            vb.Property(v => v.Id)
                .HasColumnName("ExampleVariantId")
                .ValueGeneratedOnAdd()
                .HasConversion(
                    id => id.Value,
                    value => ExampleVariantId.Create(value));

            vb.Property(v => v.Number)
                            .HasMaxLength(3);

            vb.Property(v => v.Expression)
                            .HasMaxLength(100);

            vb.Property<List<string>>("Answers") // Добавляем свойство Answers
                            .HasColumnName("Answers");
        }
    }
}
