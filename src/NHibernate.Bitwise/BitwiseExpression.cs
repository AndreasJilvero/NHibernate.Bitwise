using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using Expression = NHibernate.Criterion.Expression;

namespace NHibernate.Bitwise
{
    public class BitwiseExpression : LogicalExpression
    {
        public BitwiseExpression(string propertyName, object value, string @operator, string op)
            : base(new SimpleExpression(propertyName, value, @operator), Expression.Sql("?", value, NHibernateUtil.Enum(value.GetType())))
        {
            Op = op;
        }

        public BitwiseExpression(string propertyName, object value, string @operator)
            : base(new SimpleExpression(propertyName, value, @operator), Expression.Sql("?", value, NHibernateUtil.Enum(value.GetType())))
        {
            Op = "=";
        }

        protected override string Op { get; }

        public static BitwiseExpressionBuilder On<T>(Expression<Func<T, object>> property)
        {
            return new BitwiseExpressionBuilder(Projections.Property(property));
        }

        public static BitwiseExpressionBuilder On(string propertyName)
        {
            return new BitwiseExpressionBuilder(Projections.Property(propertyName));
        }
    }
}