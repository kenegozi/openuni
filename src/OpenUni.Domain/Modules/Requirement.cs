using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain.Modules
{
	[ActiveRecord(DiscriminatorColumn = "Type", DiscriminatorType = "string",DiscriminatorLength = "50", DiscriminatorValue = "")]
	public abstract class Requirement
	{
		[PrimaryKey]
		public virtual Guid Id { get; protected set; }
	}

	[ActiveRecord(DiscriminatorValue = "Exam")]
	public class Exam : Requirement
	{
		
	}

	[ActiveRecord(DiscriminatorValue = "Assignment")]
	public class Assignment : Requirement
	{
		[Property]
		public virtual int Weight { get; set; }
	}

	public enum RequirementType
	{
		Exam,
		Assignment
	}
}