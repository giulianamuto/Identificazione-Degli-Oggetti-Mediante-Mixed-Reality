using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Questo è l'algortimo più importante. Attenzione!!
namespace Vive.Plugin.SR.Experience
{
    [RequireComponent(typeof(ViveSR_Experience))]
    public class Sample9_SemanticSegmentation : MonoBehaviour
    {
        enum ActionMode
        {
            MeshControl,
            SemanticObjectControl,
            MaxNum
        }

        ActionMode actionMode = ActionMode.MeshControl;

        ViveSR_Experience_SemanticDrawer SemanticDrawer;
        ViveSR_Experience_StaticMesh StaticMeshScript;

        //E' una variabile che dai nell'ispector,  è il tempo dello scanner, al termine del countdown stoppa lo scanner e va avanti
        // Ho fatto varie prove, consiglio più di 60 secondi altrimenti non scannerizza bene 
        public float timeLeft = 0.0f;

        int ActionModeNum = (int)ActionMode.MaxNum;
        public bool EnablePlacer = false;



        private void Awake()
        {
            StaticMeshScript = FindObjectOfType<ViveSR_Experience_StaticMesh>();
            SemanticDrawer = FindObjectOfType<ViveSR_Experience_SemanticDrawer>();
        }

        private void Start()
        {
            ViveSR_Experience.instance.CheckHandStatus(() =>
            {
                ViveSR_RigidReconstructionRenderer.LiveMeshDisplayMode = ReconstructionDisplayMode.ADAPTIVE_MESH;
                //Parte lo scanner
                Scanning();
            });

        }

        //Qui calcolo il coutdown quando arriva a 0 viene stoppato lo scanner e parte il salvataggio della scena
        private void Update()
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                Saving();
            }
        }


        //Scanner della scena
        void Scanning()
        {
            if (!ViveSR_RigidReconstruction.IsScanning && !StaticMeshScript.ModelIsLoading && !StaticMeshScript.SemanticMeshIsLoading)
            {
                SemanticDrawer.DestroyAllObjects();
                if (StaticMeshScript.CheckModelLoaded()) StaticMeshScript.LoadMesh(false);
                StaticMeshScript.ActivateSemanticMesh(false);
                StaticMeshScript.SetScanning(true);
                StaticMeshScript.SetSegmentation(true);
            }
        }


 

        void UpdateSegmentationPercentage(int percentage)
        {
          // Debug.Log("Sto salvando");
        }
        

        //Salvataggio della scena
        void Saving()
        {
            if (ViveSR_RigidReconstruction.IsScanning)
            {

                StaticMeshScript.UnloadSemanticMesh();
                ViveSR_SceneUnderstanding.SetAllCustomSceneUnderstandingConfig(10, true);
                StaticMeshScript.SetSegmentation(false);

                StaticMeshScript.ExportSemanticMesh(UpdateSegmentationPercentage,
                    () =>
                    {
                        StaticMeshScript.ExportModel(UpdateSegmentationPercentage,
                         () =>
                         {
                             //Debug.Log("Mesh Saved");
                              Loading();
                          }
                         );
                    }
                );

            }

        }




        //Caricamento oggetti
        void Loading()
        {

            if (!ViveSR_RigidReconstruction.IsScanning && StaticMeshScript.CheckModelExist() && !StaticMeshScript.CheckModelLoaded())
            {
                SwitchMode();
                StaticMeshScript.LoadMesh(
                    true,
                    () =>
                    { // step 1
                        //Debug.Log( "Loading Scene...");
                    },
                    () =>
                    { // step 2
                        if (StaticMeshScript.CheckSemanticMeshDirExist())
                        {
                            LoadSemanticMesh();
                            StaticMeshScript.collisionMesh.SetActive(false);
                        }
                        else
                        {

                           // Debug.Log("No Object is Found.\nPlease Rescan!");
                        }
                    }
                );
            }

        }


        //Caricamento Meah
        private void LoadSemanticMesh()
        {
            StaticMeshScript.LoadSemanticMesh(
                () =>
                {
                   // Debug.Log("Loading Objects...");
                },
                () =>
                {
                    StaticMeshScript.collisionMesh.SetActive(false);

                   // Debug.Log("Mesh Loaded!");
                    SwitchMode();
                    SwitchActionMode(ActionMode.SemanticObjectControl);
                }
            );
        }


        //Vedi tutto
        private void ShowAll()
        {
            SemanticDrawer.ShowAllObjects();
            Debug.Log("Show all");
        }





        public void SwitchMode()
        {
            if (!ViveSR_RigidReconstruction.IsExportingMesh && !ViveSR_RigidReconstruction.IsScanning)
            {
                MoveToNextActionMode();
            }

        }

        void MoveToNextActionMode()
        {
            int mode_int = (int)actionMode;
            ActionMode mode = (ActionMode)((++mode_int) % ActionModeNum);
            SwitchActionMode(mode);
        }

        void SwitchActionMode(ActionMode mode)
        {
            actionMode = mode;

            if (mode == ActionMode.MeshControl) // 0
            {
                SemanticDrawer.enabled = false;
                ShowAll();
                StaticMeshScript.SwitchShowCollider(ShowMode.None); 

            }
            else if (mode == ActionMode.SemanticObjectControl) // 1
            {
                SemanticDrawer.enabled = true;
                ShowAll();
                StaticMeshScript.SwitchShowCollider(ShowMode.None);

            }
        }



    }
}
