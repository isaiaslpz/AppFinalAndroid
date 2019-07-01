using UnityEngine;
using UnityEngine.UI;

public class SliderAjout : MonoBehaviour
{
    private LoadAliment loader;
    public GameObject Aliment1; //pour le feedback visuel lorsqu'on modifie le slider
    public GameObject Aliment2; //pour le feedback visuel lorsqu'on modifie le slider
    
    public void InitAliment(){
        if (Aliment1 != null || Aliment2 != null)
        {
            GameObject.Find("SliderAjout").GetComponent<SliderAjout>().DeleteVisualFeedBack();
        }
        if (loader == null)
        {
            loader = MedicalAppManager.Instance().gameObject.GetComponent<LoadAliment>();
        }
        Aliment1 = loader.LoadWithSliceManagement(MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment);
        Aliment2 = loader.LoadWithSliceManagement(MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment);

        Aliment1.transform.position = new Vector3(-1.5f, 4.2f, 0);
        if (Aliment1.GetComponent<BlocAliment>().normal.z == 1)
        {
            Aliment1.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        Aliment2.transform.position = new Vector3(1.5f, 4.2f, 0);
        if (Aliment2.GetComponent<BlocAliment>().normal.z == 1)
        {
            Aliment2.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

		//ROTAR ALIMENTOS NECESARIOS AL ESCOGER LA PORCION--------------------------------------------------------
		if (Aliment1.name == "Riz"|| Aliment1.name == "Jambon Blanc" || Aliment1.name == "Betteraves Rouges"||Aliment1.name== "Camembert"||Aliment1.name== "Pâtes"||Aliment1.name == "Gruyère" || Aliment1.name == "Raclette" || Aliment1.name == "St Agur" || Aliment1.name == "Roquefort" || Aliment1.name == "Babybel"
		|| Aliment1.name == "Ratatouille"  || Aliment1.name == "Thon" || Aliment1.name == "Carottes râpées" || Aliment1.name == "Salade verte"|| Aliment1.name == "Gâteau chocolat") 
		{
			Aliment1.transform.rotation = Quaternion.Euler(0, 90, -90);
		}

		if (Aliment2.name == "Riz" || Aliment2.name == "Jambon Blanc" || Aliment2.name == "Betteraves Rouges"||Aliment2.name== "Camembert"||Aliment2.name== "Pâtes" || Aliment2.name == "Gruyère" || Aliment2.name == "Raclette" || Aliment2.name == "St Agur" || Aliment2.name == "Roquefort" || Aliment2.name == "Babybel"
		|| Aliment2.name == "Ratatouille"  || Aliment2.name == "Thon" || Aliment2.name == "Carottes râpées" || Aliment2.name == "Salade verte" || Aliment2.name == "Gâteau chocolat") 
		{
			Aliment2.transform.rotation = Quaternion.Euler(0, 90, -90);
		}

		GetComponent<Slider>().maxValue = MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.slices * 2;
        if (GetComponent<Slider>().value == MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.slices)
            ModificationAliment();
        GetComponent<Slider>().value = MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.slices;// en gros, la moitié du slider et l'équivalent d'un aliment plein
            
    }

    public void ModificationAliment()
    {
        int value = (int)gameObject.GetComponent<Slider>().value;
        //_MGR_MedicalApp.instance.selectedAliment.GetComponent<BlocAliment>().nbSlices = value;
        //_MGR_MedicalApp.instance.updateInfosRepas();
        GameObject Txt = gameObject.transform.parent.transform.GetChild(1).gameObject;
		Txt.GetComponent<Text>().text = MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.name
			+ ", choisissez la quantité: "; 
			//+ value.ToString() + " " + MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.mesure;

        /* modification du texte en fonction du type d'aliement
        if (MedicalAppManager.Instance().IsSelectedDrink())
        {
            Txt.GetComponent<Text>().text = MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.name + "\n" + value.ToString() + " gorgée(s)";
        }
        else
        {
            Txt.GetComponent<Text>().text = MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.name + "\n" + value.ToString() + " tranche(s)";
        }
		*/

        //feedback visuel
        if (value <= MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.slices)
       {
           Aliment1.GetComponent<BlocAliment>().nbSlices = value;
           Aliment2.GetComponent<BlocAliment>().nbSlices = 0;
       }
       else{
           Aliment1.GetComponent<BlocAliment>().nbSlices = MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.slices;
           Aliment2.GetComponent<BlocAliment>().nbSlices = value- MedicalAppManager.Instance().selectedAliment.GetComponent<BlocAliment>().aliment.slices;
       }
       Aliment1.GetComponent<BlocAliment>().SetAspectWithSlice();
       Aliment2.GetComponent<BlocAliment>().SetAspectWithSlice();
       if(Aliment1.GetComponent<BlocAliment>().aliment.multiMesh){
            Aliment1.GetComponent<BlocAliment>().SetDefaultSize();
            Aliment2.GetComponent<BlocAliment>().SetDefaultSize();
        }
    }

    public void DeleteVisualFeedBack(){

        if(Aliment1!=null){
            Destroy(Aliment1);
        }
        if(Aliment2!=null){
            Destroy(Aliment2);
        }
    }
}
