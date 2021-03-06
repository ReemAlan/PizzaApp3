//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace View.Persistence
{
	/// <summary>Static class for (extension) methods for fetching and projecting instances of View.DtoClasses.PizzaView from the entity model.</summary>
	public static partial class PizzaViewPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Restaurant.EntityClasses.PizzaEntity, View.DtoClasses.PizzaView>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Restaurant.EntityClasses.PizzaEntity, View.DtoClasses.PizzaView> _compiledProjector = CreateProjectionFunc().Compile();
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static PizzaViewPersistence() { }
	
		/// <summary>Extension method which produces a projection to View.DtoClasses.PizzaView which instances are projected from the 
		/// results of the specified baseQuery, which returns Restaurant.EntityClasses.PizzaEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve View.DtoClasses.PizzaView instances</returns>
		public static IQueryable<View.DtoClasses.PizzaView> ProjectToPizzaView(this IQueryable<Restaurant.EntityClasses.PizzaEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}
		
		/// <summary>Extension method which produces a projection to View.DtoClasses.PizzaView which instances are projected from the
		/// Restaurant.EntityClasses.PizzaEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Restaurant.EntityClasses.PizzaEntity instance created from the specified entity instance</returns>
		public static View.DtoClasses.PizzaView ProjectToPizzaView(this Restaurant.EntityClasses.PizzaEntity entity)
		{
			return _compiledProjector(entity);
		}
		
		private static System.Linq.Expressions.Expression<Func<Restaurant.EntityClasses.PizzaEntity, View.DtoClasses.PizzaView>> CreateProjectionFunc()
		{
			return p__0 => new View.DtoClasses.PizzaView()
			{
				Base = p__0.Base,
				Dough = p__0.Dough,
				Id = p__0.Id,
				OrderId = p__0.OrderId,
				PizzaToppings = p__0.PizzaToppings.Select(p__1 => new View.DtoClasses.PizzaViewTypes.PizzaTopping()
				{
					Topping = p__1.Topping,
				}).ToList(),
				Size = p__0.Size,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_PizzaView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
		}
	}
}

