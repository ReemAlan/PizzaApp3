﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace View.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'Pizza'.</summary>
	[Serializable]
	[DataContract]
	public partial class PizzaView
	{
		/// <summary>Gets or sets the Base field. Derived from Entity Model Field 'Pizza.Base (FK)'</summary>
		[DataMember]
		public System.String Base { get; set; }
		/// <summary>Gets or sets the Dough field. Derived from Entity Model Field 'Pizza.Dough (FK)'</summary>
		[DataMember]
		public System.String Dough { get; set; }
		/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Pizza.Id'</summary>
		[DataMember]
		public System.Int32 Id { get; set; }
		/// <summary>Gets or sets the OrderId field. Derived from Entity Model Field 'Pizza.OrderId (FK)'</summary>
		[DataMember]
		public System.Int32 OrderId { get; set; }
		/// <summary>Gets or sets the PizzaToppings field. </summary>
		[DataMember]
		public List<PizzaViewTypes.PizzaTopping> PizzaToppings { get; set; }
		/// <summary>Gets or sets the Size field. Derived from Entity Model Field 'Pizza.Size (FK)'</summary>
		[DataMember]
		public System.String Size { get; set; }
	}

	namespace PizzaViewTypes
	{
		/// <summary> DTO class which is derived from the entity 'PizzaTopping (PizzaToppings)'.</summary>
		[Serializable]
		[DataContract]
		public partial class PizzaTopping
		{
			/// <summary>Gets or sets the Topping field. Derived from Entity Model Field 'PizzaTopping.Topping (FK)'</summary>
			[DataMember]
			public System.String Topping { get; set; }
		}
	}

}



