using System.Collections.Generic;
using UnityEngine;

namespace LeosLib
{
	public static class Collisions
	{
		public enum Elements
		{
			Default = 0,
			Player,
			Enemy,
			Enviroment,
			Walls,
			Count
		}

		public class Box : MonoBehaviour
		{
			[SerializeField] Vector2 hitBoxRadius;
			[SerializeField] Elements type = Elements.Default;

			void Start()
			{
				CollisionManager.Instance.AddToDetector(this);
			}

			void OnDestroy()
			{
				CollisionManager.Instance.RemoveFromDetector(this);
			}

			public virtual void OnCollision(Box collision)
			{
			}

			public void SetData(Vector2 hitBox, Elements type)
			{
				hitBoxRadius = hitBox;
				this.type = type;
			}

			public Vector3 GetPosition() { return transform.position; }

			public Vector2 GetBoxValues() { return hitBoxRadius; }

			public Elements GetTypeElem() { return type; }
		}


		public class CollisionManager : MonoBehaviour
		{
			static CollisionManager instance;

			List<List<Box>> boxes;

			bool[,] relations;

			void Awake()
			{
				int count = (int)Elements.Count;

				// Boxes
				boxes = new List<List<Box>>();

				for (int i = 0; i < count; i++)
					boxes.Add(new List<Box>());

				// Relations
				relations = new bool[count, count];

				for (int c = 0; c < count; c++)
					for (int v = 0; v < count; v++)
						relations[c, v] = false;
			}

			public void LateUpdate()
			{
				CheckCollisions();
			}

			public void SetRelation(int elem1, int elem2)
			{
				if (elem1 <= elem2)
					relations[elem1, elem2] = true;
				else
					relations[elem2, elem1] = true;
			}

			void CheckCollisions()
			{
				int count = (int)Elements.Count;

				for (int i = 0; i < count; i++)
					for (int j = i; j < count; j++)
						if (relations[i,j])
							MakeTheRealDetection(boxes[i], boxes[j]);
			}

			void MakeTheRealDetection(List<Box> l1, List<Box> l2)
			{
				if (l1.Count == 0 || l2.Count == 0)
					return;

				List<Box> boxesCollided = new List<Box>();

				for (int i = 0; i < l1.Count; i++)
				{
					Vector2 hitBox1 = l1[i].GetBoxValues();

					for (int j = 0; j < l2.Count; j++)
					{
						Vector3 diff = l2[j].GetPosition() - l1[i].GetPosition();

						float diffX = Mathf.Abs(diff.x);
						float diffY = Mathf.Abs(diff.y);

						Vector2 hitBox2 = l2[i].GetBoxValues();

						if (diffX < hitBox1.x + hitBox2.x && diffY < hitBox1.y + hitBox2.y)
						{
							l1[i].OnCollision(l2[j]);
							l2[j].OnCollision(l1[i]);

							if (!l1[i]) { l1.RemoveAt(i); i--; };
							if (!l2[j]) { l2.RemoveAt(j); j--; };
						}
					}
				}
			}

			public void AddToDetector(Box tObject)
			{
				boxes[(int)tObject.GetTypeElem()].Add(tObject);
			}

			public void RemoveFromDetector(Box tObject)
			{
				boxes[(int)tObject.GetTypeElem()].Remove(tObject);
			}

			static public CollisionManager Instance
			{
				get
				{
					if (!instance)
					{
						instance = FindObjectOfType<CollisionManager>();
						if (!instance)
						{
							GameObject go = new GameObject("Managers");
							instance = go.AddComponent<CollisionManager>();
						}
					}
					return instance;
				}
			}
		}
	}
}
