using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Tests
{
    public class RootWindowsPlayModeUnitTests
    {
        public const float VisualTimer = .001f;
        
        [UnityTest]
        public IEnumerator SubjectDetailView_GetViewAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        ) {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);

// Assert
            Assert.DoesNotThrow(() => {
                SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        ) {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh();
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshAttributesAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
                IAttributeData aData = ValueSourceCommon.GetSubAttributeData();
// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshDescriptionAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                SubjectDetailView.GetView(GetUICanvas(), size, location);
            IDescriptionData dData = ValueSourceCommon.GetSubDescriptionData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(null, null, dData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshPortraitAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
            IPortraitData pData = ValueSourceCommon.GetSubPortraitData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(null, pData, null);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshAttributesPortraitAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
            IAttributeData aData = ValueSourceCommon.GetSubAttributeData();
            IPortraitData pData = ValueSourceCommon.GetSubPortraitData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData, pData, null);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshAttributesDescriptionAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
            IAttributeData aData = ValueSourceCommon.GetSubAttributeData();
            IDescriptionData dData = ValueSourceCommon.GetSubDescriptionData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData, null, dData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshAttributesDescriptionPortraitAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
            IAttributeData aData = ValueSourceCommon.GetSubAttributeData();
            IDescriptionData dData = ValueSourceCommon.GetSubDescriptionData();
            IPortraitData pData = ValueSourceCommon.GetSubPortraitData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData, pData, dData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator SubjectDetailView_RefreshDescriptionPortraitAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(GetUICanvas(), size, location);
            IPortraitData pData = ValueSourceCommon.GetSubPortraitData();
            IDescriptionData dData = ValueSourceCommon.GetSubDescriptionData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(null, pData, dData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

// Subject UnityTests
        [UnityTest]
        public IEnumerator Subject_ShowDetailAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            Subject subjectUnderTest = new Subject(GetUICanvas());

// Assert
            Assert.DoesNotThrow(() => {
                subjectUnderTest.ShowDetail(location, size);
            });
            yield return new WaitForSeconds(VisualTimer);
// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Subject_HideDetailAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            Subject subjectUnderTest = new Subject(GetUICanvas());
            subjectUnderTest.ShowDetail(location, size);

// Assert
            yield return new WaitForSeconds(VisualTimer * .5f);
            Assert.DoesNotThrow(() => {
                subjectUnderTest.HideDetail();
            });
            yield return new WaitForSeconds(VisualTimer * .5f);

// Tear Down
            DestroyAllGameObjects();
        }

// ActionBarView UnityTests
        [UnityTest]
        public IEnumerator ActionBarView_Refresh_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh();
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ActionBarView_RefreshSelfActions_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    ValueSourceCommon.StubNoArgActionList(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ActionBarView_RefreshLocationActions_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    null,
                    ValueSourceCommon.StubV3ArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ActionBarView_RefreshObjectActions_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    null,
                    null,
                    ValueSourceCommon.StubGameObjectArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ActionBarView_RefreshSelfLocationActions_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    ValueSourceCommon.StubNoArgActionList(5),
                    ValueSourceCommon.StubV3ArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ActionBarView_RefreshSelfLocationObjectActions_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    ValueSourceCommon.StubNoArgActionList(5),
                    ValueSourceCommon.StubV3ArgActionDict(5),
                    ValueSourceCommon.StubGameObjectArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ActionBarView_RefreshLocationObjectActions_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            CreateTestCamera();
            CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            CreateEventSystem();
            ActionBarView abView = 
                ActionBarView.GetView(GetUICanvas(), size, location);
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    null,
                    ValueSourceCommon.StubV3ArgActionDict(5),
                    ValueSourceCommon.StubGameObjectArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            DestroyAllGameObjects();
        }

// Set Up Methods
        private void CreateTestCamera() {
            GameObject cameraObj = new GameObject("Test Camera");
            cameraObj.tag = "MainCamera";
            Camera camera = cameraObj.AddComponent<Camera>();
        }

        private Canvas GetUICanvas() {
            GameObject resultObj = new GameObject("UI Test Canvas");
            Canvas result = resultObj.AddComponent<Canvas>();
            result.renderMode = RenderMode.ScreenSpaceOverlay;
            return result;
        }

        private EventSystem CreateEventSystem() {
            GameObject resultObj = new GameObject("Event System");
            EventSystem resultMono = resultObj.AddComponent<EventSystem>();
            return resultMono;
        }

        private void CreateTestNameCanvas(string testName) {
            Canvas canvas = 
                new GameObject("Test Name Canvas").AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            GameObject imageObj = new GameObject("Test Name Background Object");
            Image image = imageObj.AddComponent<Image>();
            image.color = new Color(1f, 1f, 1f, .5f);
            imageObj.transform.SetParent(canvas.transform, false);

            GameObject textObj = new GameObject("Test Name Image Object");
            Text text = textObj.AddComponent<Text>();
            text.AsText("Test Name: " + testName);
            text.fontSize = 24;
            textObj.transform.SetParent(imageObj.transform, false);

            RectTransform imageRect = imageObj.GetComponent<RectTransform>();
            RectTransform textRect = textObj.GetComponent<RectTransform>();

            imageRect.anchorMin = new Vector2(.5f, 1f);
            imageRect.anchorMax = new Vector2(.5f, 1f);
            imageRect.sizeDelta = new Vector2(Screen.width, Screen.height * 0.05f);
            textRect.sizeDelta = imageRect.sizeDelta;
            imageRect.localPosition = new Vector2(
                imageRect.localPosition.x, 
                imageRect.localPosition.y - (imageRect.sizeDelta.y / 2f)
            );
        }

// Tear Down Methods
        private void DestroyAllGameObjects() {
            GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
            
            for (int i = 0; i < objects.Length; i++) {
                GameObject.Destroy(objects[i]);
            }
        }
    }
}
