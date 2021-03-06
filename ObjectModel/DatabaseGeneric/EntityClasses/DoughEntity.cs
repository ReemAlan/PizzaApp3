//////////////////////////////////////////////////////////////
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

	/// <summary>Entity class which represents the entity 'Dough'.<br/><br/></summary>
	[Serializable]
	public partial class DoughEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<PizzaEntity> _pizzas;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static DoughEntityStaticMetaData _staticMetaData = new DoughEntityStaticMetaData();
		private static DoughRelations _relationsFactory = new DoughRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Pizzas</summary>
			public static readonly string Pizzas = "Pizzas";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class DoughEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public DoughEntityStaticMetaData()
			{
				SetEntityCoreInfo("DoughEntity", InheritanceHierarchyType.None, false, (int)Restaurant.EntityType.DoughEntity, typeof(DoughEntity), typeof(DoughEntityFactory), false);
				AddNavigatorMetaData<DoughEntity, EntityCollection<PizzaEntity>>("Pizzas", a => a._pizzas, (a, b) => a._pizzas = b, a => a.Pizzas, () => new DoughRelations().PizzaEntityUsingDough, typeof(PizzaEntity), (int)Restaurant.EntityType.PizzaEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static DoughEntity()
		{
		}

		/// <summary> CTor</summary>
		public DoughEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public DoughEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this DoughEntity</param>
		public DoughEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="option">PK value for Dough which data should be fetched into this Dough object</param>
		public DoughEntity(System.String option) : this(option, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="option">PK value for Dough which data should be fetched into this Dough object</param>
		/// <param name="validator">The custom validator object for this DoughEntity</param>
		public DoughEntity(System.String option, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Option = option;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DoughEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
		/// <param name="validator">The validator object for this DoughEntity</param>
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
		public static DoughRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Pizza' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPizzas { get { return _staticMetaData.GetPrefetchPathElement("Pizzas", CommonEntityBase.CreateEntityCollection<PizzaEntity>()); } }

		/// <summary>The Option property of the Entity Dough<br/><br/></summary>
		/// <remarks>Mapped on  table field: "dough"."option".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.String Option
		{
			get { return (System.String)GetValue((int)DoughFieldIndex.Option, true); }
			set	{ SetValue((int)DoughFieldIndex.Option, value); }
		}

		/// <summary>The Price property of the Entity Dough<br/><br/></summary>
		/// <remarks>Mapped on  table field: "dough"."price".<br/>Table field type characteristics (type, precision, scale, length): Money, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)DoughFieldIndex.Price, true); }
			set	{ SetValue((int)DoughFieldIndex.Price, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'PizzaEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(PizzaEntity))]
		public virtual EntityCollection<PizzaEntity> Pizzas { get { return GetOrCreateEntityCollection<PizzaEntity, PizzaEntityFactory>("Dough1", true, false, ref _pizzas); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace Restaurant
{
	public enum DoughFieldIndex
	{
		///<summary>Option. </summary>
		Option,
		///<summary>Price. </summary>
		Price,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Restaurant.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Dough. </summary>
	public partial class DoughRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between DoughEntity and PizzaEntity over the 1:n relation they have, using the relation between the fields: Dough.Option - Pizza.Dough</summary>
		public virtual IEntityRelation PizzaEntityUsingDough
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "Pizzas", true, new[] { DoughFields.Option, PizzaFields.Dough }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticDoughRelations
	{
		internal static readonly IEntityRelation PizzaEntityUsingDoughStatic = new DoughRelations().PizzaEntityUsingDough;

		/// <summary>CTor</summary>
		static StaticDoughRelations() { }
	}
}
