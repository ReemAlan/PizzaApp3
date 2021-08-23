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

	/// <summary>Entity class which represents the entity 'Pizza'.<br/><br/></summary>
	[Serializable]
	public partial class PizzaEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<PizzaToppingEntity> _pizzaToppings;
		private BaseEntity _base1;
		private DoughEntity _dough1;
		private OrderEntity _order;
		private SizeEntity _size1;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static PizzaEntityStaticMetaData _staticMetaData = new PizzaEntityStaticMetaData();
		private static PizzaRelations _relationsFactory = new PizzaRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Base1</summary>
			public static readonly string Base1 = "Base1";
			/// <summary>Member name Dough1</summary>
			public static readonly string Dough1 = "Dough1";
			/// <summary>Member name Order</summary>
			public static readonly string Order = "Order";
			/// <summary>Member name Size1</summary>
			public static readonly string Size1 = "Size1";
			/// <summary>Member name PizzaToppings</summary>
			public static readonly string PizzaToppings = "PizzaToppings";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class PizzaEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public PizzaEntityStaticMetaData()
			{
				SetEntityCoreInfo("PizzaEntity", InheritanceHierarchyType.None, false, (int)Restaurant.EntityType.PizzaEntity, typeof(PizzaEntity), typeof(PizzaEntityFactory), false);
				AddNavigatorMetaData<PizzaEntity, EntityCollection<PizzaToppingEntity>>("PizzaToppings", a => a._pizzaToppings, (a, b) => a._pizzaToppings = b, a => a.PizzaToppings, () => new PizzaRelations().PizzaToppingEntityUsingPizzaId, typeof(PizzaToppingEntity), (int)Restaurant.EntityType.PizzaToppingEntity);
				AddNavigatorMetaData<PizzaEntity, BaseEntity>("Base1", "Pizzas", (a, b) => a._base1 = b, a => a._base1, (a, b) => a.Base1 = b, Restaurant.RelationClasses.StaticPizzaRelations.BaseEntityUsingBaseStatic, ()=>new PizzaRelations().BaseEntityUsingBase, null, new int[] { (int)PizzaFieldIndex.Base }, null, true, (int)Restaurant.EntityType.BaseEntity);
				AddNavigatorMetaData<PizzaEntity, DoughEntity>("Dough1", "Pizzas", (a, b) => a._dough1 = b, a => a._dough1, (a, b) => a.Dough1 = b, Restaurant.RelationClasses.StaticPizzaRelations.DoughEntityUsingDoughStatic, ()=>new PizzaRelations().DoughEntityUsingDough, null, new int[] { (int)PizzaFieldIndex.Dough }, null, true, (int)Restaurant.EntityType.DoughEntity);
				AddNavigatorMetaData<PizzaEntity, OrderEntity>("Order", "Pizzas", (a, b) => a._order = b, a => a._order, (a, b) => a.Order = b, Restaurant.RelationClasses.StaticPizzaRelations.OrderEntityUsingOrderIdStatic, ()=>new PizzaRelations().OrderEntityUsingOrderId, null, new int[] { (int)PizzaFieldIndex.OrderId }, null, true, (int)Restaurant.EntityType.OrderEntity);
				AddNavigatorMetaData<PizzaEntity, SizeEntity>("Size1", "Pizzas", (a, b) => a._size1 = b, a => a._size1, (a, b) => a.Size1 = b, Restaurant.RelationClasses.StaticPizzaRelations.SizeEntityUsingSizeStatic, ()=>new PizzaRelations().SizeEntityUsingSize, null, new int[] { (int)PizzaFieldIndex.Size }, null, true, (int)Restaurant.EntityType.SizeEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static PizzaEntity()
		{
		}

		/// <summary> CTor</summary>
		public PizzaEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PizzaEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PizzaEntity</param>
		public PizzaEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Pizza which data should be fetched into this Pizza object</param>
		public PizzaEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Pizza which data should be fetched into this Pizza object</param>
		/// <param name="validator">The custom validator object for this PizzaEntity</param>
		public PizzaEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PizzaEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'PizzaTopping' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPizzaToppings() { return CreateRelationInfoForNavigator("PizzaToppings"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Base' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBase1() { return CreateRelationInfoForNavigator("Base1"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Dough' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDough1() { return CreateRelationInfoForNavigator("Dough1"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Order' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrder() { return CreateRelationInfoForNavigator("Order"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Size' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSize1() { return CreateRelationInfoForNavigator("Size1"); }
		
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
		/// <param name="validator">The validator object for this PizzaEntity</param>
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
		public static PizzaRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PizzaTopping' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPizzaToppings { get { return _staticMetaData.GetPrefetchPathElement("PizzaToppings", CommonEntityBase.CreateEntityCollection<PizzaToppingEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Base' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBase1 { get { return _staticMetaData.GetPrefetchPathElement("Base1", CommonEntityBase.CreateEntityCollection<BaseEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Dough' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDough1 { get { return _staticMetaData.GetPrefetchPathElement("Dough1", CommonEntityBase.CreateEntityCollection<DoughEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Order' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrder { get { return _staticMetaData.GetPrefetchPathElement("Order", CommonEntityBase.CreateEntityCollection<OrderEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Size' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSize1 { get { return _staticMetaData.GetPrefetchPathElement("Size1", CommonEntityBase.CreateEntityCollection<SizeEntity>()); } }

		/// <summary>The Base property of the Entity Pizza<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza"."base".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Base
		{
			get { return (System.String)GetValue((int)PizzaFieldIndex.Base, true); }
			set	{ SetValue((int)PizzaFieldIndex.Base, value); }
		}

		/// <summary>The Dough property of the Entity Pizza<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza"."dough".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Dough
		{
			get { return (System.String)GetValue((int)PizzaFieldIndex.Dough, true); }
			set	{ SetValue((int)PizzaFieldIndex.Dough, value); }
		}

		/// <summary>The Id property of the Entity Pizza<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza"."id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)PizzaFieldIndex.Id, true); }
			set { SetValue((int)PizzaFieldIndex.Id, value); }		}

		/// <summary>The OrderId property of the Entity Pizza<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza"."order_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 OrderId
		{
			get { return (System.Int32)GetValue((int)PizzaFieldIndex.OrderId, true); }
			set	{ SetValue((int)PizzaFieldIndex.OrderId, value); }
		}

		/// <summary>The Size property of the Entity Pizza<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza"."size".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Size
		{
			get { return (System.String)GetValue((int)PizzaFieldIndex.Size, true); }
			set	{ SetValue((int)PizzaFieldIndex.Size, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'PizzaToppingEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(PizzaToppingEntity))]
		public virtual EntityCollection<PizzaToppingEntity> PizzaToppings { get { return GetOrCreateEntityCollection<PizzaToppingEntity, PizzaToppingEntityFactory>("Pizza", true, false, ref _pizzaToppings); } }

		/// <summary>Gets / sets related entity of type 'BaseEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual BaseEntity Base1
		{
			get { return _base1; }
			set { SetSingleRelatedEntityNavigator(value, "Base1"); }
		}

		/// <summary>Gets / sets related entity of type 'DoughEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual DoughEntity Dough1
		{
			get { return _dough1; }
			set { SetSingleRelatedEntityNavigator(value, "Dough1"); }
		}

		/// <summary>Gets / sets related entity of type 'OrderEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual OrderEntity Order
		{
			get { return _order; }
			set { SetSingleRelatedEntityNavigator(value, "Order"); }
		}

		/// <summary>Gets / sets related entity of type 'SizeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual SizeEntity Size1
		{
			get { return _size1; }
			set { SetSingleRelatedEntityNavigator(value, "Size1"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace Restaurant
{
	public enum PizzaFieldIndex
	{
		///<summary>Base. </summary>
		Base,
		///<summary>Dough. </summary>
		Dough,
		///<summary>Id. </summary>
		Id,
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>Size. </summary>
		Size,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Restaurant.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Pizza. </summary>
	public partial class PizzaRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between PizzaEntity and PizzaToppingEntity over the 1:n relation they have, using the relation between the fields: Pizza.Id - PizzaTopping.PizzaId</summary>
		public virtual IEntityRelation PizzaToppingEntityUsingPizzaId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "PizzaToppings", true, new[] { PizzaFields.Id, PizzaToppingFields.PizzaId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PizzaEntity and BaseEntity over the m:1 relation they have, using the relation between the fields: Pizza.Base - Base.Option</summary>
		public virtual IEntityRelation BaseEntityUsingBase
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Base1", false, new[] { BaseFields.Option, PizzaFields.Base }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PizzaEntity and DoughEntity over the m:1 relation they have, using the relation between the fields: Pizza.Dough - Dough.Option</summary>
		public virtual IEntityRelation DoughEntityUsingDough
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Dough1", false, new[] { DoughFields.Option, PizzaFields.Dough }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PizzaEntity and OrderEntity over the m:1 relation they have, using the relation between the fields: Pizza.OrderId - Order.Id</summary>
		public virtual IEntityRelation OrderEntityUsingOrderId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Order", false, new[] { OrderFields.Id, PizzaFields.OrderId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PizzaEntity and SizeEntity over the m:1 relation they have, using the relation between the fields: Pizza.Size - Size.Option</summary>
		public virtual IEntityRelation SizeEntityUsingSize
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Size1", false, new[] { SizeFields.Option, PizzaFields.Size }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticPizzaRelations
	{
		internal static readonly IEntityRelation PizzaToppingEntityUsingPizzaIdStatic = new PizzaRelations().PizzaToppingEntityUsingPizzaId;
		internal static readonly IEntityRelation BaseEntityUsingBaseStatic = new PizzaRelations().BaseEntityUsingBase;
		internal static readonly IEntityRelation DoughEntityUsingDoughStatic = new PizzaRelations().DoughEntityUsingDough;
		internal static readonly IEntityRelation OrderEntityUsingOrderIdStatic = new PizzaRelations().OrderEntityUsingOrderId;
		internal static readonly IEntityRelation SizeEntityUsingSizeStatic = new PizzaRelations().SizeEntityUsingSize;

		/// <summary>CTor</summary>
		static StaticPizzaRelations() { }
	}
}
