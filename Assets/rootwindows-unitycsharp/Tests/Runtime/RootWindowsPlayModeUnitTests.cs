using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RootExtensions;


namespace Tests
{
    public class SubjectDetailViewTests {
        public const float VisualTimer = .001f;

        [UnityTest]
        public IEnumerator GetView_AllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        ) {
// Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

// Assert
            Assert.DoesNotThrow(() => {
                SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );
            });
            
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_NoArgAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        ) {
// Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh();
            });
            
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_AttributesArgAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );
            
            IAttributeData aData = ValueSourceCommon.GetMockAttributeData();
// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_DetailArgAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );
            
            SubjectDetailView detailView = 
                SubjectDetailView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
            IDescriptionData dData = ValueSourceCommon.GetMockDescriptionData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(null, null, dData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_PortraitArgAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );
            
            IPortraitData pData = ValueSourceCommon.GetMockPortraitData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(null, pData, null);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_AttributePortraitArgsAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );
                
            IAttributeData aData = ValueSourceCommon.GetMockAttributeData();
            IPortraitData pData = ValueSourceCommon.GetMockPortraitData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData, pData, null);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_AttributesDescriptionArgsAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );

            IAttributeData aData = ValueSourceCommon.GetMockAttributeData();
            IDescriptionData dData = ValueSourceCommon.GetMockDescriptionData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData, null, dData);
            });
            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_AttributesDescriptionPortraitArgsAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );
            
            IAttributeData aData = ValueSourceCommon.GetMockAttributeData();
            IDescriptionData dData = ValueSourceCommon.GetMockDescriptionData();
            IPortraitData pData = ValueSourceCommon.GetMockPortraitData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(aData, pData, dData);
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_DescriptionPortraitArgsAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size
        )
        {
// Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            
            SubjectDetailView detailView = 
                    SubjectDetailView.GetView(
                        SetUpCommon.GetUICanvas(),
                        size,
                        location
                    );
            
            IPortraitData pData = ValueSourceCommon.GetMockPortraitData();
            IDescriptionData dData = ValueSourceCommon.GetMockDescriptionData();

// Assert
            Assert.DoesNotThrow(() => {
                detailView.Refresh(null, pData, dData);
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }
    }

    public class ActionViewBarTests {
        public const float VisualTimer = .001f;

        // ActionBarView UnityTests
        [UnityTest]
        public IEnumerator Refresh_NoArg_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(TestContext.CurrentContext.Test.Name);
            
            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh();
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_SelfAbilitiesArg_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    ValueSourceCommon.StubNoArgActionList(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_LocationAbilitiesArg_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    null,
                    ValueSourceCommon.StubV3ArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_ObjectAbilitiesArg_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
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
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_SelfLocationAbilitiesArgs_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
// Assert
            Assert.DoesNotThrow(() => {
                abView.Refresh(
                    ValueSourceCommon.StubNoArgActionList(5),
                    ValueSourceCommon.StubV3ArgActionDict(5)
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_SelfLocationObjectAbilitiesArgs_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
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
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator Refresh_LocationObjectAbilitiesArgs_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );
            
            SetUpCommon.CreateEventSystem();
            
            ActionBarView abView = 
                ActionBarView.GetView(
                    SetUpCommon.GetUICanvas(),
                    size,
                    location
                );
            
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
            TearDownCommon.DestroyAllGameObjects();
        }
    }

    public class RootWindowsTests {
        public const float VisualTimer = .001f;

        [UnityTest]
        public IEnumerator RegisterViewData_AttributeViewDataArg_DoesNotThrowException() {
// Set Up            
            GameObject testObj = new GameObject("testobj");
            RootWindows testMono = testObj.AddComponent<RootWindows>();
            IAttributeData testData = ValueSourceCommon.GetMockAttributeData();
            
// Assert
            Assert.DoesNotThrow(() => {
                RootWindows.RegisterViewData("test", testData);
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator RegisterSelfAbility_NoArgActionArgs_DoesNotThrowException() {
// Set Up            
            GameObject testObj = new GameObject("testobj");
            RootWindows testMono = testObj.AddComponent<RootWindows>();
            
// Assert
            Assert.DoesNotThrow(() => {
                RootWindows.RegisterSelfAbility(
                    "test",
                    ValueSourceCommon.GetMockNoArgAction(),
                    ValueSourceCommon.GetMockNoArgAction()
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator RegisterLocationAbility_NoArgV3ArgActionArgs_DoesNotThrowException() {
// Set Up            
            GameObject testObj = new GameObject("testobj");
            RootWindows testMono = testObj.AddComponent<RootWindows>();
            
// Assert
            Assert.DoesNotThrow(() => {
                RootWindows.RegisterLocationAbility(
                    "test",
                    ValueSourceCommon.GetMockNoArgAction(),
                    ValueSourceCommon.GetMockV3ArgAction()
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator RegisterObjectAbility_NoArgObjectArrayArgActionArgs_DoesNotThrowException() {
// Set Up            
            GameObject testObj = new GameObject("testobj");
            RootWindows testMono = testObj.AddComponent<RootWindows>();
            
// Assert
            Assert.DoesNotThrow(() => {
                RootWindows.RegisterObjectAbility(
                    "test",
                    ValueSourceCommon.GetMockNoArgAction(),
                    ValueSourceCommon.GetMockObjectArrayArgAction()
                );
            });

            yield return new WaitForSeconds(VisualTimer);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }
    }
    
    public class SubjectTests {
        public const float VisualTimer = .001f;
        
// Subject UnityTests
        [UnityTest]
        public IEnumerator ShowDetail_WithNoDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subjectUnderTest = new Subject(
                SetUpCommon.GetUICanvas()
            );

// Assert
            Assert.DoesNotThrow(() => {
                subjectUnderTest.ShowDetail(location, size);
            });

            yield return new WaitForSeconds(VisualTimer);
// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ShowDetail_WithAttributeDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subject = new Subject(SetUpCommon.GetUICanvas());

            subject.TryAddData(
                ValueSourceCommon.GetMockAttributeData()
            );

// Assert
            Assert.DoesNotThrow(() => {
                subject.ShowDetail(location, size);
            });

            yield return new WaitForSeconds(VisualTimer);
// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ShowDetail_WithPortraitDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subject = new Subject(SetUpCommon.GetUICanvas());

            subject.TryAddData(
                ValueSourceCommon.GetMockPortraitData()
            );

// Assert
            Assert.DoesNotThrow(() => {
                subject.ShowDetail(location, size);
            });

            yield return new WaitForSeconds(VisualTimer);
// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator ShowDetail_WithDescriptionDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subject = new Subject(SetUpCommon.GetUICanvas());

            subject.TryAddData(
                ValueSourceCommon.GetMockDescriptionData()
            );

// Assert
            Assert.DoesNotThrow(() => {
                subject.ShowDetail(location, size);
            });

            yield return new WaitForSeconds(VisualTimer);
// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator HideDetail_WithNoDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subjectUnderTest = new Subject(
                SetUpCommon.GetUICanvas()
            );

            subjectUnderTest.ShowDetail(location, size);

// Assert
            yield return new WaitForSeconds(VisualTimer * .5f);
            
            Assert.DoesNotThrow(() => {
                subjectUnderTest.HideDetail();
            });
            
            yield return new WaitForSeconds(VisualTimer * .5f);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator HideDetail_WithAttributeDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subjectUnderTest = new Subject(
                SetUpCommon.GetUICanvas()
            );

            subjectUnderTest.TryAddData(
                ValueSourceCommon.GetMockAttributeData()
            );

            subjectUnderTest.ShowDetail(location, size);

// Assert
            yield return new WaitForSeconds(VisualTimer * .5f);
            
            Assert.DoesNotThrow(() => {
                subjectUnderTest.HideDetail();
            });
            
            yield return new WaitForSeconds(VisualTimer * .5f);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator HideDetail_WithPortraitDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subjectUnderTest = new Subject(
                SetUpCommon.GetUICanvas()
            );

            subjectUnderTest.TryAddData(
                ValueSourceCommon.GetMockPortraitData()
            );

            subjectUnderTest.ShowDetail(location, size);

// Assert
            yield return new WaitForSeconds(VisualTimer * .5f);
            
            Assert.DoesNotThrow(() => {
                subjectUnderTest.HideDetail();
            });
            
            yield return new WaitForSeconds(VisualTimer * .5f);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }

        [UnityTest]
        public IEnumerator HideDetail_WithDescriptionDataAllLocationsSizes_DoesNotThrowException(
            [ValueSource(typeof(ValueSourceCommon), "AllViewLocations")]
            CardinalDirections location,
            [ValueSource(typeof(ValueSourceCommon), "AllViewSizes")]
            ViewSizes size 
        ) {
//  Set Up
            SetUpCommon.CreateTestCamera();
            SetUpCommon.CreateTestNameCanvas(
                TestContext.CurrentContext.Test.Name
            );

            Subject subjectUnderTest = new Subject(
                SetUpCommon.GetUICanvas()
            );

            subjectUnderTest.TryAddData(
                ValueSourceCommon.GetMockDescriptionData()
            );

            subjectUnderTest.ShowDetail(location, size);

// Assert
            yield return new WaitForSeconds(VisualTimer * .5f);
            
            Assert.DoesNotThrow(() => {
                subjectUnderTest.HideDetail();
            });
            
            yield return new WaitForSeconds(VisualTimer * .5f);

// Tear Down
            TearDownCommon.DestroyAllGameObjects();
        }
    }

    public static class SetUpCommon {
        // Set Up Methods
        public static void CreateTestCamera() {
            GameObject cameraObj = new GameObject("Test Camera");
            cameraObj.tag = "MainCamera";
            Camera camera = cameraObj.AddComponent<Camera>();
        }

        public static Canvas GetUICanvas() {
            GameObject resultObj = new GameObject("UI Test Canvas");
            Canvas result = resultObj.AddComponent<Canvas>();
            result.renderMode = RenderMode.ScreenSpaceOverlay;
            return result;
        }

        public static EventSystem CreateEventSystem() {
            GameObject resultObj = new GameObject("Event System");
            EventSystem resultMono = resultObj.AddComponent<EventSystem>();
            return resultMono;
        }

        public static void CreateTestNameCanvas(string testName) {
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
    }

    public static class TearDownCommon {
        // Tear Down Methods
        public static void DestroyAllGameObjects() {
            GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
            
            for (int i = 0; i < objects.Length; i++) {
                GameObject.Destroy(objects[i]);
            }
        }
    }
}

