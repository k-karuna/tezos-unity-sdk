using System;
using TezosSDK.Tezos;
using TMPro;
using UnityEngine;

namespace TezosSDK.Examples.WalletConnection.Scripts
{

	public class MetadataInfoUI : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI nameText;
		[SerializeField] private TextMeshProUGUI descriptionText;

		private void Start()
		{
			nameText.text = TezosManager.Instance.DAppMetadata.Name;
			descriptionText.text = "-";
		}
	}

}