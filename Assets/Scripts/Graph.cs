using UnityEngine;

public class Graph : MonoBehaviour
{

	[SerializeField] private Transform pointPrefab;
	[SerializeField, Range(10, 100)] private int resolution = 10;

        private Transform[] points;
	
	void Awake () {
                float step = 2f / resolution;
                Vector3 position = Vector3.zero;
                var scale = Vector3.one * step;

                points = new Transform[resolution];
                for (int idx = 0; idx < points.Length; idx++) {
                        Transform point = Instantiate(pointPrefab);
                        points[idx] = point;

                        position.x = (idx + 0.5f) * step - 1f;
                        point.localPosition = position;
                        point.localScale = scale; // Each cube has size 1 in each dimension by default, so to make them fit we have to reduce their scale
                        point.SetParent(transform, false);
                }
	}

        void Update() {
                float time = Time.time;
                for (int idx = 0; idx < points.Length; idx++) {
                        Transform point = points[idx];
                        Vector3 position = point.localPosition;
                        position.y = Mathf.Sin(Mathf.PI * (position.x + time));
                        point.localPosition = position;
                }
        }
}
