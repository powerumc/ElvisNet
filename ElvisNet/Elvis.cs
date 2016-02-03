using System;
using System.Linq.Expressions;

namespace ElvisNet
{
	public static class Elvis
	{
		public static T Value<T>(Expression<Func<T>> expression)
		{
			if (expression.NodeType == ExpressionType.Lambda && 
				(expression.Body.NodeType == ExpressionType.MemberAccess || expression.Body.NodeType == ExpressionType.Call)) {
				var compile = expression.Compile ();
				try 
				{
					T value = compile ();
					return value;
				} 
				catch (NullReferenceException) 
				{
					return default(T);
				}
			}

			throw new NotSupportedException (expression.ToString());
		}
	}
}

