﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Restaurant.HelperClasses;
using Restaurant.FactoryClasses;
using Restaurant.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Restaurant.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'Order'.<br/><br/></summary>
	[Serializable]
	public partial class OrderEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<PizzaEntity> _pizzas;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static OrderEntityStaticMetaData _staticMetaData = new OrderEntityStaticMetaData();
		private static OrderRelations _relationsFactory = new OrderRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Pizzas</summary>
			public static readonly string Pizzas = "Pizzas";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class OrderEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public OrderEntityStaticMetaData()
			{
				SetEntityCoreInfo("OrderEntity", InheritanceHierarchyType.None, false, (int)Restaurant.EntityType.OrderEntity, typeof(OrderEntity), typeof(OrderEntityFactory), false);
				AddNavigatorMetaData<OrderEntity, EntityCollection<PizzaEntity>>("Pizzas", a => a._pizzas, (a, b) => a._pizzas = b, a => a.Pizzas, () => new OrderRelations().PizzaEntityUsingOrderId, typeof(PizzaEntity), (int)Restaurant.EntityType.PizzaEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static OrderEntity()
		{
		}

		/// <summary> CTor</summary>
		public OrderEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OrderEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OrderEntity</param>
		public OrderEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Order which data should be fetched into this Order object</param>
		public OrderEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Order which data should be fetched into this Order object</param>
		/// <param name="validator">The custom validator object for this OrderEntity</param>
		public OrderEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrderEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Pizza' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPizzas() { return CreateRelationInfoForNavigator("Pizzas"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OrderEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END


			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static OrderRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Pizza' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPizzas { get { return _staticMetaData.GetPrefetchPathElement("Pizzas", CommonEntityBase.CreateEntityCollection<PizzaEntity>()); } }

		/// <summary>The CustomerName property of the Entity Order<br/><br/></summary>
		/// <remarks>Mapped on  table field: "order"."customer_name".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CustomerName
		{
			get { return (System.String)GetValue((int)OrderFieldIndex.CustomerName, true); }
			set	{ SetValue((int)OrderFieldIndex.CustomerName, value); }
		}

		/// <summary>The Id property of the Entity Order<br/><br/></summary>
		/// <remarks>Mapped on  table field: "order"."id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)OrderFieldIndex.Id, true); }
			set { SetValue((int)OrderFieldIndex.Id, value); }		}

		/// <summary>Gets the EntityCollection with the related entities of type 'PizzaEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(PizzaEntity))]
		public virtual EntityCollection<PizzaEntity> Pizzas { get { return GetOrCreateEntityCollection<PizzaEntity, PizzaEntityFactory>("Order", true, false, ref _pizzas); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace Restaurant
{
	public enum OrderFieldIndex
	{
		///<summary>CustomerName. </summary>
		CustomerName,
		///<summary>Id. </summary>
		Id,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Restaurant.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Order. </summary>
	public partial class OrderRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between OrderEntity and PizzaEntity over the 1:n relation they have, using the relation between the fields: Order.Id - Pizza.OrderId</summary>
		public virtual IEntityRelation PizzaEntityUsingOrderId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "Pizzas", true, new[] { OrderFields.Id, PizzaFields.OrderId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticOrderRelations
	{
		internal static readonly IEntityRelation PizzaEntityUsingOrderIdStatic = new OrderRelations().PizzaEntityUsingOrderId;

		/// <summary>CTor</summary>
		static StaticOrderRelations() { }
	}
}