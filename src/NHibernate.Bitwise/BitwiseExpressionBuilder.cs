using System;
using System.Linq;
using NHibernate.Criterion;

namespace NHibernate.Bitwise
{
    public class BitwiseExpressionBuilder
    {
        public BitwiseExpressionBuilder(IPropertyProjection projection)
        {
            Projection = projection;
        }

        public IPropertyProjection Projection { get; set; }

        public ICriterion HasBit(Enum value)
        {
            return new BitwiseExpression(Projection.PropertyName, value, " & ");
        }

        public ICriterion HasAny(params Enum[] values)
        {
            var disjunction = Restrictions.Disjunction();
            foreach (var value in values)
            {
                disjunction.Add(HasBit(value));
            }

            return disjunction;
        }
    }
}