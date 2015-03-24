using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
	[TestFixture]
	internal class MatrixDecompositionTest {

		[Test]
		public void TestDecomposition () {
			System.Object[][] matrix = new System.Object[][]{
				new System.Object[]{1,2,3},
				new System.Object[]{4,5,6},
				new System.Object[]{7,8,9}
			};
			
			
			List<System.Object> result = MatrixDecomposition.DecomposeMatrix (matrix);
			// matrix area should match spiral length
			Assert.That(result.Count,Is.EqualTo(matrix.Length * matrix[0].Length));
			// matrix 0,0 should equal result 0
			Assert.That(result[0],Is.EqualTo(matrix[0][0]));
		}
	}
}