using System;
using System.Linq;
using System.Linq.Expressions;

namespace System
{
	public static class Elvis
	{
		public static T SafeNull<T>(this Expression<Func<T>> expression)
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

		public static T SafeNull<T>(this Func<T> func)
		{
			try 
			{
				return func();
			} 
			catch (NullReferenceException) 
			{
				return default(T);
			}
		}
	}
}

