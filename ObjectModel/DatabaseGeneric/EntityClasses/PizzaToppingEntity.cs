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

	/// <summary>Entity class which represents the entity 'PizzaTopping'.<br/><br/></summary>
	[Serializable]
	public partial class PizzaToppingEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private PizzaEntity _pizza;
		private ToppingEntity _topping1;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static PizzaToppingEntityStaticMetaData _staticMetaData = new PizzaToppingEntityStaticMetaData();
		private static PizzaToppingRelations _relationsFactory = new PizzaToppingRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Pizza</summary>
			public static readonly string Pizza = "Pizza";
			/// <summary>Member name Topping1</summary>
			public static readonly string Topping1 = "Topping1";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class PizzaToppingEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public PizzaToppingEntityStaticMetaData()
			{
				SetEntityCoreInfo("PizzaToppingEntity", InheritanceHierarchyType.None, false, (int)Restaurant.EntityType.PizzaToppingEntity, typeof(PizzaToppingEntity), typeof(PizzaToppingEntityFactory), false);
				AddNavigatorMetaData<PizzaToppingEntity, PizzaEntity>("Pizza", "PizzaToppings", (a, b) => a._pizza = b, a => a._pizza, (a, b) => a.Pizza = b, Restaurant.RelationClasses.StaticPizzaToppingRelations.PizzaEntityUsingPizzaIdStatic, ()=>new PizzaToppingRelations().PizzaEntityUsingPizzaId, null, new int[] { (int)PizzaToppingFieldIndex.PizzaId }, null, true, (int)Restaurant.EntityType.PizzaEntity);
				AddNavigatorMetaData<PizzaToppingEntity, ToppingEntity>("Topping1", "PizzaToppings", (a, b) => a._topping1 = b, a => a._topping1, (a, b) => a.Topping1 = b, Restaurant.RelationClasses.StaticPizzaToppingRelations.ToppingEntityUsingToppingStatic, ()=>new PizzaToppingRelations().ToppingEntityUsingTopping, null, new int[] { (int)PizzaToppingFieldIndex.Topping }, null, true, (int)Restaurant.EntityType.ToppingEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static PizzaToppingEntity()
		{
		}

		/// <summary> CTor</summary>
		public PizzaToppingEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PizzaToppingEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PizzaToppingEntity</param>
		public PizzaToppingEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="pizzaId">PK value for PizzaTopping which data should be fetched into this PizzaTopping object</param>
		/// <param name="topping">PK value for PizzaTopping which data should be fetched into this PizzaTopping object</param>
		public PizzaToppingEntity(System.Int32 pizzaId, System.String topping) : this(pizzaId, topping, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="pizzaId">PK value for PizzaTopping which data should be fetched into this PizzaTopping object</param>
		/// <param name="topping">PK value for PizzaTopping which data should be fetched into this PizzaTopping object</param>
		/// <param name="validator">The custom validator object for this PizzaToppingEntity</param>
		public PizzaToppingEntity(System.Int32 pizzaId, System.String topping, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.PizzaId = pizzaId;
			this.Topping = topping;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PizzaToppingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Pizza' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPizza() { return CreateRelationInfoForNavigator("Pizza"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Topping' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTopping1() { return CreateRelationInfoForNavigator("Topping1"); }
		
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
		/// <param name="validator">The validator object for this PizzaToppingEntity</param>
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
		public static PizzaToppingRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Pizza' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPizza { get { return _staticMetaData.GetPrefetchPathElement("Pizza", CommonEntityBase.CreateEntityCollection<PizzaEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Topping' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTopping1 { get { return _staticMetaData.GetPrefetchPathElement("Topping1", CommonEntityBase.CreateEntityCollection<ToppingEntity>()); } }

		/// <summary>The PizzaId property of the Entity PizzaTopping<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza_topping"."pizza_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 PizzaId
		{
			get { return (System.Int32)GetValue((int)PizzaToppingFieldIndex.PizzaId, true); }
			set	{ SetValue((int)PizzaToppingFieldIndex.PizzaId, value); }
		}

		/// <summary>The Topping property of the Entity PizzaTopping<br/><br/></summary>
		/// <remarks>Mapped on  table field: "pizza_topping"."topping".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.String Topping
		{
			get { return (System.String)GetValue((int)PizzaToppingFieldIndex.Topping, true); }
			set	{ SetValue((int)PizzaToppingFieldIndex.Topping, value); }
		}

		/// <summary>Gets / sets related entity of type 'PizzaEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual PizzaEntity Pizza
		{
			get { return _pizza; }
			set { SetSingleRelatedEntityNavigator(value, "Pizza"); }
		}

		/// <summary>Gets / sets related entity of type 'ToppingEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual ToppingEntity Topping1
		{
			get { return _topping1; }
			set { SetSingleRelatedEntityNavigator(value, "Topping1"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace Restaurant
{
	public enum PizzaToppingFieldIndex
	{
		///<summary>PizzaId. </summary>
		PizzaId,
		///<summary>Topping. </summary>
		Topping,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Restaurant.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: PizzaTopping. </summary>
	public partial class PizzaToppingRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between PizzaToppingEntity and PizzaEntity over the m:1 relation they have, using the relation between the fields: PizzaTopping.PizzaId - Pizza.Id</summary>
		public virtual IEntityRelation PizzaEntityUsingPizzaId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Pizza", false, new[] { PizzaFields.Id, PizzaToppingFields.PizzaId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PizzaToppingEntity and ToppingEntity over the m:1 relation they have, using the relation between the fields: PizzaTopping.Topping - Topping.Option</summary>
		public virtual IEntityRelation ToppingEntityUsingTopping
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Topping1", false, new[] { ToppingFields.Option, PizzaToppingFields.Topping }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticPizzaToppingRelations
	{
		internal static readonly IEntityRelation PizzaEntityUsingPizzaIdStatic = new PizzaToppingRelations().PizzaEntityUsingPizzaId;
		internal static readonly IEntityRelation ToppingEntityUsingToppingStatic = new PizzaToppingRelations().ToppingEntityUsingTopping;

		/// <summary>CTor</summary>
		static StaticPizzaToppingRelations() { }
	}
}