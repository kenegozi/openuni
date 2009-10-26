using System;

namespace OpenUni.Web.UI.Services
{
	public class Term : IEquatable<Term>, IComparable<Term>
	{
		private readonly int _year;
		private readonly byte _termNo;

		public Term(int year, byte termNo)
		{
			_year = year;
			_termNo = termNo;
		}

		public int CompareTo(Term other)
		{
			Func<Term,int>  val = t => t._year*10 + t._termNo;

			return val(this).CompareTo(val(other));
		}

		public override string ToString()
		{
			return "" + _year + (char)('à' + (_termNo - 1));
		}

		public static implicit operator string(Term term)
		{
			return term.ToString();
		}

		public bool Equals(Term other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other._year == _year && other._termNo == _termNo;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Term)) return false;
			return Equals((Term) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (_year*397) ^ _termNo.GetHashCode();
			}
		}

		public static bool operator ==(Term left, Term right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Term left, Term right)
		{
			return !Equals(left, right);
		}
	}
}