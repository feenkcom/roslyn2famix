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


			private List<Treasure> hoard;

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
			MetaRepository metaRepo = new MetaRepository();
			metaRepo.With(typeof(Dragon));
			metaRepo.With(typeof(Treasure));
			Assert.IsNotNull(metaRepo.Get("RPG.Dragon"));
			Assert.IsNotNull(metaRepo.Get("RPG.Treasure"));
			//TODO next: implement Repository.elements
		}
	}
}
