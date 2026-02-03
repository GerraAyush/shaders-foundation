using UnityEngine;

public class Graph : MonoBehaviour
{

	[SerializeField] private Transform pointPrefab;
	[SerializeField, Range(10, 100)] private int resolution = 10;
	[SerializeField] private FunctionLibrary.FunctionName function = 0;

        private Transform[] points;
	
	void Awake () {
                float step = 2f / resolution;
                var scale = Vector3.one * step;

                points = new Transform[resolution * resolution];
                for (int idx = 0; idx < points.Length; idx++) {
                        Transform point = points[idx] = Instantiate(pointPrefab);
                        point.localScale = scale; // Each cube has size 1 in each dimension by default, so to make them fit we have to reduce their scale
                        point.SetParent(transform, false);
                }
	}

        void Update() {
                float time = Time.time;
                float step = 2f / resolution;
                FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);

                float v = 0.5f * step - 1f;
                for (int idx = 0, x = 0, z = 0; idx < points.Length; idx++, x++) {
                        if (x == resolution) {
                                x = 0;
                                z += 1;
                                v = (z + 0.5f) * step - 1f;
                        }
                        float u = (x + 0.5f) * step - 1;
                        points[idx].localPosition = f(u, v, time);
                }
        }
}
