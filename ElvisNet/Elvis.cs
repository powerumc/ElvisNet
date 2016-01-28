using System;
using System.Linq.Expressions;

namespace ElvisNet
{
	public class Elvis
	{
		public Elvis ()
		{
		}

		public static object Value<T>(Expression<Func<T>> expression)
		{
			var visitor = new ElvisExpressionVisitor ();
			return visitor.Visit (expression);
		}
	}
}

