using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ElvisNet
{
	public class ElvisExpressionVisitor
	{
		public object Visit(Expression expression) 
		{
			var visitor = new ElvisExpressionVisitor ();
			switch (expression.NodeType) {
			case ExpressionType.Lambda:
				return Visit(((LambdaExpression)expression).Body);
			
			case ExpressionType.MemberAccess:
				var me = (MemberExpression)expression;
				return Visit ((Expression)me.Expression);
			
			case ExpressionType.Constant:
				return VisitConstants ((ConstantExpression)expression);
			}

			return null;
		}

		protected void VisitMember(MemberInfo memberInfo)
		{
			if (memberInfo is FieldInfo) {
				var fi = (FieldInfo)memberInfo;
				var value = fi.GetValue (null);
			}
			else if (memberInfo is MethodInfo) {
			}
		}

		protected object VisitConstants (ConstantExpression constantExpression)
		{
			return constantExpression.Value;
		}
	}
}

