using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace WebClientSDK.Scripts.Editor {


public class TheFastUiLayout : AbstractEditorWindow<TheFastUiLayout> {
	public Object TMP_FontAsset_1;
	public Object TMP_FontAsset_2;
	public int OrderInLayer;

	[Range(0, 1)] public int _Fade;

	bool AutoAnchorMode;

	Vector2 _minAnchor, _maxAnchor;

	enum AutoAnchorModeState {
		enable, disable
	}

	AutoAnchorModeState _currentAutoAnchorMode = AutoAnchorModeState.disable;

	[MenuItem("Инструменты моджахеда/Быстрая верстка")]
	public static void ShowWindow() {
		GetWindow<TheFastUiLayout>("Верстальщик");
	}


	protected override void OnGUI() {
		AutoAnchorMode = EditorGUILayout.Toggle("Auto anchor mode:", AutoAnchorMode);
		if (AutoAnchorMode && _currentAutoAnchorMode == AutoAnchorModeState.disable) {
			_currentAutoAnchorMode = AutoAnchorModeState.enable;
			Debug.Log("Auto anchor mode enable");
			SceneView.onSceneGUIDelegate += OnScene;
		}
		else 
		if (! AutoAnchorMode && _currentAutoAnchorMode == AutoAnchorModeState.enable) {
			_currentAutoAnchorMode = AutoAnchorModeState.disable;
			Debug.Log("Auto anchor mode disable");
			SceneView.onSceneGUIDelegate -= OnScene;
		}

		GUILayout.Label("Семпаааай >__<", EditorStyles.boldLabel);

		CreateButtonForMethod(SetObjectAndChildAnchorsOnVertices);
		CreateButtonForMethod(SetObjectAnchorsOnVertices);
		CreateButtonForMethod(SetObjectVerticesOnAnchors);
		CreateButtonForMethod(SetNativeSize);

		EditorGUILayout.LabelField("Шрифт 1");
		TMP_FontAsset_1 = EditorGUILayout.ObjectField(TMP_FontAsset_1, typeof(TMP_FontAsset), false);

		EditorGUILayout.LabelField("Шрифт 2");
		TMP_FontAsset_2 = EditorGUILayout.ObjectField(TMP_FontAsset_2, typeof(TMP_FontAsset), false);

		EditorGUILayout.LabelField("Назначить дочерним TMP шрифт %номер%", EditorStyles.helpBox);

		if (GUILayout.Button("1"))
			SetFontToAllChildTMP((TMP_FontAsset) TMP_FontAsset_1);

		if (GUILayout.Button("2"))
			SetFontToAllChildTMP((TMP_FontAsset) TMP_FontAsset_2);

		CreateButtonForMethod(CopyAnchorParams);
		CreateButtonForMethod(PasteAnchorParam);

		OrderInLayer = EditorGUILayout.IntField(OrderInLayer);
		CreateButtonForMethod(SetOrderInLayer);

		_Fade = EditorGUILayout.IntSlider(_Fade, 0, 255);
		CreateButtonForMethod(SetFade, "Установить прозрачность объекту и всем его детям");
	}

//	void CreateButtonForMethod(Action method, [CanBeNull] string btnName = null) {
//		if (ReferenceEquals(btnName, null)) btnName = $"{method.Method.Name}";
//		if (GUILayout.Button(btnName)) method();
//	}

	void OnScene(SceneView sceneView) {
		if (Event.current.type == EventType.MouseUp && Event.current.button == 0
		                                            && Selection.GetTransforms(SelectionMode.Deep).Length > 0) {
			Debug.Log("click");
			SetObjectAndChildAnchorsOnVertices();
		}
	}

	void SetObjectVerticesOnAnchors() {
		foreach (GameObject gameObj in Selection.gameObjects) {
			RectTransform rectTransform = gameObj.GetComponent<RectTransform>();
			if (rectTransform != null) {
				rectTransform.sizeDelta = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
			}
			else
				Debug.LogWarning("Один из выбранных объектов не содержит RectTransform");
		}
	}

	void ResetAnchor() {
		foreach (GameObject gameObj in Selection.gameObjects) {
			RectTransform rectTransform = gameObj.GetComponent<RectTransform>();
			if (rectTransform != null) {
			}
			else
				Debug.LogWarning("Один из выбранных объектов не содержит RectTransform");
		}
	}


	void SetObjectAnchorsOnVertices() {
		RectTransform rectTransform = Selection.activeGameObject.GetComponent<RectTransform>();

		SetAnchorsOnVertices(rectTransform);
	}	
	
	void SetObjectAndChildAnchorsOnVertices() {
		foreach (GameObject gameObj in Selection.gameObjects) {
			foreach (RectTransform rectTransform in gameObj.GetComponentsInChildren<RectTransform>()) {
				SetAnchorsOnVertices(rectTransform);
			}
		}
	}	
	
	public static void SetObjectAndChildAnchorsOnVertices(RectTransform rTransform) {
		foreach (RectTransform rectTransform in rTransform.GetComponentsInChildren<RectTransform>()) {
			SetAnchorsOnVertices(rectTransform);
		}
	}

	public static void SetAnchorsOnVertices(RectTransform rectTransform) {
		if (rectTransform != null) {
			Rect rectTransformRect = rectTransform.rect;
			Vector2 pivot = rectTransform.pivot;
			Vector2 anchoredPosition = rectTransform.anchoredPosition;

			RectTransform parentRectTransform = rectTransform.parent.gameObject.GetComponent<RectTransform>();
			Rect parentRect = parentRectTransform.rect;

			float pivotX = rectTransformRect.width * pivot.x;
			float pivotY = rectTransformRect.height * (1 - pivot.y);

			Vector2 newRect = new Vector2(
				rectTransform.anchorMin.x * parentRect.width + rectTransform.offsetMin.x + pivotX -
				parentRect.width * anchoredPosition.x,
				-(1 - rectTransform.anchorMax.y) * parentRect.height + rectTransform.offsetMax.y - pivotY +
				parentRect.height * (1 - anchoredPosition.y));

			rectTransformRect.x = newRect.x;
			rectTransformRect.y = newRect.y;

			Vector3 localScale = rectTransform.localScale;

			rectTransform.anchorMin = new Vector2(0f, 1f);
			rectTransform.anchorMax = new Vector2(0f, 1f);

			rectTransform.offsetMin = new Vector2(
				rectTransformRect.x / localScale.x,
				rectTransformRect.y / localScale.y - rectTransformRect.height);

			rectTransform.offsetMax = new Vector2(
				rectTransformRect.x / localScale.x + rectTransformRect.width,
				rectTransformRect.y / localScale.y);

			rectTransform.anchorMin = new Vector2(
				rectTransform.anchorMin.x + anchoredPosition.x +
				(rectTransform.offsetMin.x - pivotX) / parentRect.width * localScale.x,
				rectTransform.anchorMin.y - (1 - anchoredPosition.y) +
				(rectTransform.offsetMin.y + pivotY) / parentRect.height * localScale.y);

			rectTransform.anchorMax = new Vector2(
				rectTransform.anchorMax.x + anchoredPosition.x +
				(rectTransform.offsetMax.x - pivotX) / parentRect.width * localScale.x,
				rectTransform.anchorMax.y - (1 - anchoredPosition.y) +
				(rectTransform.offsetMax.y + pivotY) / parentRect.height * localScale.y);

			rectTransform.offsetMin = new Vector2(
				(0 - pivot.x) * rectTransformRect.width * (1 - localScale.x),
				(0 - pivot.y) * rectTransformRect.height * (1 - localScale.y));

			rectTransform.offsetMax = new Vector2(
				(1 - pivot.x) * rectTransformRect.width * (1 - localScale.x),
				(1 - pivot.y) * rectTransformRect.height * (1 - localScale.y));
		}
		else
			Debug.LogWarning("Один из выбранных объектов не содержит RectTransform");
	}

	void SetNativeSize() {
		foreach (GameObject gameObj in Selection.gameObjects) {
			Image image = gameObj.GetComponent<Image>();
			if (image != null)
				image.SetNativeSize();
			else
				Debug.LogWarning("Один из выбранных объектов не содержит Image");
		}
	}

	void SetFontToAllChildTMP(TMP_FontAsset fontAsset) {
		if (fontAsset != null) {
			foreach (Transform objTransform in Selection.transforms) {
				TextMeshProUGUI[] textMeshProUGUI = objTransform.GetComponentsInChildren<TextMeshProUGUI>();
				foreach (TextMeshProUGUI TMP in textMeshProUGUI)
					TMP.font = fontAsset;
			}
		}
		else
			Debug.LogError("Не назначен один из шрифтов!!!!!");
	}

	void CopyAnchorParams() {
		RectTransform rectTransform = Selection.activeGameObject.GetComponent<RectTransform>();

		if (rectTransform == null)
			return;

		_minAnchor = rectTransform.anchorMin;
		_maxAnchor = rectTransform.anchorMax;
	}

	void PasteAnchorParam() {
		RectTransform rectTransform = Selection.activeGameObject.GetComponent<RectTransform>();

		if (rectTransform == null)
			return;

		rectTransform.anchorMin = _minAnchor;
		rectTransform.anchorMax = _maxAnchor;
	}

	void SetOrderInLayer() {
		foreach (GameObject gameObj in Selection.gameObjects) {
			foreach (SpriteRenderer spriteRenderer in gameObj.GetComponentsInChildren<SpriteRenderer>())
				if (spriteRenderer != null)
					spriteRenderer.sortingOrder = OrderInLayer;
		}
	}

	void SetFade() {
		float fade = _Fade / 255f;

		foreach (GameObject gameObj in Selection.gameObjects) {
			foreach (Image img in gameObj.GetComponentsInChildren<Image>())
				if (img != null) {
//                    img.DOFade(fade, 3);
//                    img.CrossFadeAlpha(fade, 3, false);
					Color color = img.color;
					color = new Color(color.r, color.g, color.b, fade);
					img.color = color;
				}

			foreach (RawImage img in gameObj.GetComponentsInChildren<RawImage>())
				if (img != null) {
					Color color = img.color;
					color = new Color(color.r, color.g, color.b, fade);
					img.color = color;
				}

			foreach (TextMeshProUGUI txt in gameObj.GetComponentsInChildren<TextMeshProUGUI>())
				if (txt != null) {
					Color color = txt.color;
					color = new Color(color.r, color.g, color.b, fade);
					txt.color = color;
				}
		}
	}


}

}