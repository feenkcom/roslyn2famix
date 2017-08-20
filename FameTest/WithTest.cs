using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fame;
using System.Collections.Generic;

namespace FameTest
{
	[TestClass]
	public class WithTest
	{

		[FamePackage("RPG")]
		[FameDescription("Dragon")]
		class Dragon
		{


			private List<Treasure> hoard = new List<Treasure>();

			[FameProperty(Name = "hoard")]
			public List<Treasure> Hoard
			{
				get { return hoard; }
				set { hoard = value; }
			}

			public void AddHoard(Treasure t)
			{
				hoard.Add(t);
			}
		}

		[FamePackage("RPG")]
		[FameDescription("Treasure")]
		class Treasure
		{
		}

		[TestMethod]
		public void LeDragonTest()
		{
			Tower t = new Fame.Tower();
			MetaRepository metaRepo = t.metamodel;
			metaRepo.With(typeof(Dragon));
			metaRepo.With(typeof(Treasure));
			Assert.IsNotNull(metaRepo.Get("RPG.Dragon"));
			Assert.IsNotNull(metaRepo.Get("RPG.Treasure"));
			Dragon leDragon = t.model.NewInstance<Dragon>("RPG.Dragon");
			Treasure deltaHoard = t.model.NewInstance<Treasure>("RPG.Treasure");
			leDragon.AddHoard(deltaHoard);

			Assert.IsNotNull(leDragon);
			Assert.IsNotNull(deltaHoard);
			
			t.model.ExportMSEFile("C:/Users/george/out.mse");
		}
	}
}
