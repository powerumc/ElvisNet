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
					var value = compile ();
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

        public static T SafeNull<T>(this T obj)
        {
            try
            {
                if (obj == null) return default(T);

                return obj;
            }
            catch (NullReferenceException)
            {
                return default(T);
            }
        }

        public static TResult SafeNull<TInput, TResult>(this TInput obj, Func<TInput, TResult> func)
        {
            try
            {
                if (obj == null) return default(TResult);

                return func(obj);
            }
            catch (NullReferenceException)
            {
                return default(TResult);
            }
        }
    }
}

