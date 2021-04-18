using System;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;

namespace CharityApplication.Models
{
	class Smart2
	{
		//Rinkeby Configuration
		public static async Task<string> regFunc(int userId, string name)
		{
			var privateKey = "0x663d76c2dfeb3a0dce01178c6fb72b978603fd7e4aaf44d6030a4e70956cf3db";
			var account = new Account(privateKey);
			var web3 = new Web3(account, "https://rinkeby.infura.io/v3/aed105d4f1364e188fba9f1295c89452");
			var abi = @"[
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""userId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			}
		],
		""name"": ""donate"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""donor"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""organization"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""cause"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Donate"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""goal"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regCause"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Register"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regOrg"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regUser"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getOrg"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsCollected"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeCount"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getOrgCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getUser"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""username"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsDonated"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getUserCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]"; 
			var contract = web3.Eth.GetContract(abi, "0xb770688B8eE45da5b5F649597b87A1ed8a0A5EEe");
			var regUserFunction = contract.GetFunction("regUser");
			var gas = await regUserFunction.EstimateGasAsync(account.Address, null, null, new Object[] { userId, name });
			var receiptFirstAmountSend = await regUserFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gas, null, null, new Object[] { userId, name });
			return (receiptFirstAmountSend.TransactionHash);
		}

		public static async Task<string> donate(int amount, int userId, int orgId, int causeId)
		{
			var privateKey = "0x663d76c2dfeb3a0dce01178c6fb72b978603fd7e4aaf44d6030a4e70956cf3db";
			var account = new Account(privateKey);
			var web3 = new Web3(account, "https://rinkeby.infura.io/v3/aed105d4f1364e188fba9f1295c89452");
			var abi = @"[
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""userId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			}
		],
		""name"": ""donate"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""donor"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""organization"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""cause"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Donate"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""goal"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regCause"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Register"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regOrg"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regUser"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getOrg"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsCollected"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeCount"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getOrgCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getUser"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""username"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsDonated"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getUserCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";
			var contract = web3.Eth.GetContract(abi, "0xb770688B8eE45da5b5F649597b87A1ed8a0A5EEe");
			var regUserFunction = contract.GetFunction("donate");
			var gas = await regUserFunction.EstimateGasAsync(account.Address, null, null, new Object[] { amount, userId, orgId, causeId });
			var receiptFirstAmountSend = await regUserFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gas, null, null, new Object[] { amount, userId, orgId, causeId });
			return (receiptFirstAmountSend.TransactionHash);
		}

		public static async Task<string> regOrg(int orgId, string name)
		{
			var privateKey = "0x663d76c2dfeb3a0dce01178c6fb72b978603fd7e4aaf44d6030a4e70956cf3db";
			var account = new Account(privateKey);
			var web3 = new Web3(account, "https://rinkeby.infura.io/v3/aed105d4f1364e188fba9f1295c89452");
			var abi = @"[
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""userId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			}
		],
		""name"": ""donate"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""donor"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""organization"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""cause"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Donate"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""goal"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regCause"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Register"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regOrg"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regUser"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getOrg"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsCollected"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeCount"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getOrgCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getUser"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""username"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsDonated"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getUserCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";
			var contract = web3.Eth.GetContract(abi, "0xb770688B8eE45da5b5F649597b87A1ed8a0A5EEe");
			var regUserFunction = contract.GetFunction("regOrg");
			var gas = await regUserFunction.EstimateGasAsync(account.Address, null, null, new Object[] { orgId, name });
			var receiptFirstAmountSend = await regUserFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gas, null, null, new Object[] { orgId, name });
			return (receiptFirstAmountSend.TransactionHash);
		}

		public static async Task<string> regCause(int orgId, int causeId, int goal, string name)
		{
			var privateKey = "0x663d76c2dfeb3a0dce01178c6fb72b978603fd7e4aaf44d6030a4e70956cf3db";
			var account = new Account(privateKey);
			var web3 = new Web3(account, "https://rinkeby.infura.io/v3/aed105d4f1364e188fba9f1295c89452");
			var abi = @"[
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""userId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			}
		],
		""name"": ""donate"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""donor"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""organization"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""cause"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""amount"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Donate"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""orgId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeId"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""goal"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regCause"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""message"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""time"",
				""type"": ""uint256""
			}
		],
		""name"": ""Register"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regOrg"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			}
		],
		""name"": ""regUser"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getOrg"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""name"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsCollected"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""causeCount"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getOrgCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""id"",
				""type"": ""uint256""
			}
		],
		""name"": ""getUser"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""username"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""fundsDonated"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""getUserCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""count"",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";
			var contract = web3.Eth.GetContract(abi, "0xb770688B8eE45da5b5F649597b87A1ed8a0A5EEe");
			var regUserFunction = contract.GetFunction("regCause");
			var gas = await regUserFunction.EstimateGasAsync(account.Address, null, null, new Object[] { orgId, causeId, goal, name });
			var receiptFirstAmountSend = await regUserFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gas, null, null, new Object[] { orgId, causeId, goal, name });
			return (receiptFirstAmountSend.TransactionHash);
		}
	}
}