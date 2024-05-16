using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Common.Models;
using TestsBuilder.Domain.Test.ValueObjects;

namespace TestsBuilder.Domain.Test.Entities
{
    public sealed class Example : Entity<ExampleId>
    {
        public string Text { get; private set; }

        public string Name { get; private set; }

        public List<string> BaseAnswers { get; private set; }

        private readonly List<ExampleVariant> _variants = new();

        public IReadOnlyList<ExampleVariant> Variants => _variants.AsReadOnly();

        // Публичный конструктор без параметров (необходим для EF Core)
        public Example() : base(ExampleId.CreateUnique())
        {
        }

        private Example(ExampleId exampleId,string name, string text, List<string> baseAnswers, List<ExampleVariant>? variants) : base(exampleId)
        {
            Name = name;
            Text = text;
            BaseAnswers = baseAnswers;
            if (variants != null)
            {
                _variants.AddRange(variants);
            }
        }

        public static Example Create(string name, string text, List<string> baseAnswers, List<ExampleVariant> variants)
        {
            return new(
                ExampleId.CreateUnique(),
                name,
                text,
                baseAnswers,
                variants);
        }
    }

}
