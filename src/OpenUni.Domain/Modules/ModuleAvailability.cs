using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain.Modules
{
	[ActiveRecord("ModulesAvailability")]
	public class ModuleAvailability
	{
		Module module;
		int year;
		byte termNo;
		int capacity;

		protected ModuleAvailability(){}
		
		public ModuleAvailability(int capacity, byte termNo, int year, Module module)
		{
			this.capacity = capacity;
			this.module = module;
			this.year = year;
			this.termNo = termNo;
		}

		[PrimaryKey(PrimaryKeyType.GuidComb)]
		public virtual Guid Id { get; private set; }

		[BelongsTo("ModuleId", Access = PropertyAccess.NosetterCamelcase)]
		public virtual Module Module
		{
			get { return module; }
		}

		[Property(Access = PropertyAccess.NosetterCamelcase)]
		public virtual int Year
		{
			get { return year; }
		}

		[Property(Access = PropertyAccess.NosetterCamelcase)]
		public virtual byte TermNo
		{
			get { return termNo; }
		}

		[Property(Access = PropertyAccess.NosetterCamelcase)]
		public virtual int Capacity
		{
			get { return capacity; }
		}


	}

	class MyClass
	{
		public Module module;
		public int Capacity;
		public int Openings;
	}
}