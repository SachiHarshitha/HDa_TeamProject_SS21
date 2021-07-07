using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace INTRANAV.Contracts.Assets.ContractDefinition
{


    public partial class AssetsDeployment : AssetsDeploymentBase
    {
        public AssetsDeployment() : base(BYTECODE) { }
        public AssetsDeployment(string byteCode) : base(byteCode) { }
    }

    public class AssetsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50612cfc806100206000396000f3fe608060405234801561001057600080fd5b50600436106100885760003560e01c80636c958cfc1161005b5780636c958cfc146101ec578063862b33d91461034a578063d7c1d2d7146103c7578063f8a07c27146103f957610088565b8063017088e41461008d578063234e6f3a146100ae5780633c90d572146100b65780633ded33bc146101c6575b600080fd5b61009561041f565b6040805163ffffffff9092168252519081900360200190f35b610095610438565b6101c4600480360360608110156100cc57600080fd5b810190602081018135600160201b8111156100e657600080fd5b8201836020820111156100f857600080fd5b803590602001918460018302840111600160201b8311171561011957600080fd5b919390929091602081019035600160201b81111561013657600080fd5b82018360208201111561014857600080fd5b803590602001918460018302840111600160201b8311171561016957600080fd5b919390929091602081019035600160201b81111561018657600080fd5b82018360208201111561019857600080fd5b803590602001918460018302840111600160201b831117156101b957600080fd5b509092509050610451565b005b6101c4600480360360208110156101dc57600080fd5b50356001600160a01b0316610697565b6101c46004803603608081101561020257600080fd5b810190602081018135600160201b81111561021c57600080fd5b82018360208201111561022e57600080fd5b803590602001918460018302840111600160201b8311171561024f57600080fd5b919390929091602081019035600160201b81111561026c57600080fd5b82018360208201111561027e57600080fd5b803590602001918460018302840111600160201b8311171561029f57600080fd5b919390929091602081019035600160201b8111156102bc57600080fd5b8201836020820111156102ce57600080fd5b803590602001918460018302840111600160201b831117156102ef57600080fd5b919390929091602081019035600160201b81111561030c57600080fd5b82018360208201111561031e57600080fd5b803590602001918460018302840111600160201b8311171561033f57600080fd5b5090925090506106c1565b610352610924565b6040805160208082528351818301528351919283929083019185019080838360005b8381101561038c578181015183820152602001610374565b50505050905090810190601f1680156103b95780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6101c4600480360360408110156103dd57600080fd5b5080356001600160a01b0316906020013563ffffffff16610a59565b6101c46004803603602081101561040f57600080fd5b50356001600160a01b0316610abe565b3360009081526020819052604090205463ffffffff1690565b3360009081526001602052604090205463ffffffff1690565b336000818152602081815260408083205460019283905292205463ffffffff928316908316909101909116116104b85760405162461bcd60e51b8152600401808060200182810382526042815260200180612c866042913960600191505060405180910390fd5b736f485c8bf6fc43ea212e93bbf8ce046c7f1cb4756040516104d990610b2e565b6001600160a01b03909116815260405190819003602001906000f080158015610506573d6000803e3d6000fd5b50600380546001600160a01b0319166001600160a01b039283161790819055604051631e486ab960e11b8152606060048201908152606482018a90529190921691633c90d572918a918a918a918a918a918a91908190602481019060448101906084018a8a80828437600083820152601f01601f191690910185810384528881526020019050888880828437600083820152601f01601f191690910185810383528681526020019050868680828437600081840152601f19601f8201169050808301925050509950505050505050505050600060405180830381600087803b1580156105f157600080fd5b505af1158015610605573d6000803e3d6000fd5b5050506001600160a01b03821660009081526020818152604091829020805463ffffffff8082166001011663ffffffff199091161790558151818152600d918101919091526c185cdcd95d0811195b195d1959609a1b8183015290513392507f618191079b759c0e8f74514441817b7d0c6dee793d7edc2ac0fbff12ca88f8939181900360600190a250505050505050565b61069f610b0c565b600280546001600160a01b0319166001600160a01b0392909216919091179055565b3360008181526020819052604090205463ffffffff166107125760405162461bcd60e51b8152600401808060200182810382526042815260200180612c866042913960600191505060405180910390fd5b736f485c8bf6fc43ea212e93bbf8ce046c7f1cb47560405161073390610b2e565b6001600160a01b03909116815260405190819003602001906000f080158015610760573d6000803e3d6000fd5b50600380546001600160a01b0319166001600160a01b039283161790819055604051631a5947fd60e01b8152608060048201908152608482018c90529190921691631a5947fd918c918c918c918c918c918c918c918c9190819060248101906044810190606481019060a4018d8d80828437600083820152601f01601f191690910186810385528b815260200190508b8b80828437600083820152601f01601f191690910186810384528981526020019050898980828437600083820152601f01601f191690910186810383528781526020019050878780828437600081840152601f19601f8201169050808301925050509c50505050505050505050505050600060405180830381600087803b15801561087a57600080fd5b505af115801561088e573d6000803e3d6000fd5b5050506001600160a01b03821660009081526020818152604091829020805460001963ffffffff808316919091011663ffffffff199091161790558151818152600b918101919091526a185cdcd95d08105919195960aa1b8183015290513392507f618191079b759c0e8f74514441817b7d0c6dee793d7edc2ac0fbff12ca88f8939181900360600190a2505050505050505050565b60035460408051637831b00360e11b815290516060926001600160a01b03169163f0636006916004808301926000929190829003018186803b15801561096957600080fd5b505afa15801561097d573d6000803e3d6000fd5b505050506040513d6000823e601f3d908101601f1916820160405260208110156109a657600080fd5b8101908080516040519392919084600160201b8211156109c557600080fd5b9083019060208201858111156109da57600080fd5b8251600160201b8111828201881017156109f357600080fd5b82525081516020918201929091019080838360005b83811015610a20578181015183820152602001610a08565b50505050905090810190601f168015610a4d5780820380516001836020036101000a031916815260200191505b50604052505050905090565b6002546001600160a01b03163314610a7057600080fd5b6001600160a01b0391909116600090815260208181526040808320805463ffffffff1980821663ffffffff928316880183161790925560019093529220805492831692821690930116179055565b6002546001600160a01b03163314610ad557600080fd5b6001600160a01b0316600090815260208181526040808320805463ffffffff19908116909155600190925290912080549091169055565b3373b8b76e5a4aebbe98d09b5deb92a9505a6df8f1fb14610b2c57600080fd5b565b61214a80610b3c8339019056fe608060405260405161214a38038061214a8339818101604052602081101561002657600080fd5b5051600180546001600160a01b0383166001600160a01b0319918216179091556006805490911633179055604080516020808252604b9082018190527f11a3fca63f87bd67d7f9f72b744acc8be2193705e7a734ac3a773d35d259e87b928291908201906120ff823960600191505060405180910390a150612052806100ad6000396000f3fe6080604052600436106100705760003560e01c806327dc297e1161004e57806327dc297e146103f257806338bbfa50146104aa5780633c90d572146105e7578063f06360061461079557610070565b80631a5947fd146100755780631eb2ad48146102aa578063218648eb1461034e575b600080fd5b6102a86004803603608081101561008b57600080fd5b810190602081018135600160201b8111156100a557600080fd5b8201836020820111156100b757600080fd5b803590602001918460018302840111600160201b831117156100d857600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295949360208101935035915050600160201b81111561012a57600080fd5b82018360208201111561013c57600080fd5b803590602001918460018302840111600160201b8311171561015d57600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295949360208101935035915050600160201b8111156101af57600080fd5b8201836020820111156101c157600080fd5b803590602001918460018302840111600160201b831117156101e257600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295949360208101935035915050600160201b81111561023457600080fd5b82018360208201111561024657600080fd5b803590602001918460018302840111600160201b8311171561026757600080fd5b91908080601f01602080910402602001604051908101604052809392919081815260200183838082843760009201919091525092955061081f945050505050565b005b6102a8600480360360208110156102c057600080fd5b810190602081018135600160201b8111156102da57600080fd5b8201836020820111156102ec57600080fd5b803590602001918460018302840111600160201b8311171561030d57600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295506109b1945050505050565b6102a86004803603602081101561036457600080fd5b810190602081018135600160201b81111561037e57600080fd5b82018360208201111561039057600080fd5b803590602001918460018302840111600160201b831117156103b157600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610b3d945050505050565b3480156103fe57600080fd5b506102a86004803603604081101561041557600080fd5b81359190810190604081016020820135600160201b81111561043657600080fd5b82018360208201111561044857600080fd5b803590602001918460018302840111600160201b8311171561046957600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610bca945050505050565b3480156104b657600080fd5b506102a8600480360360608110156104cd57600080fd5b81359190810190604081016020820135600160201b8111156104ee57600080fd5b82018360208201111561050057600080fd5b803590602001918460018302840111600160201b8311171561052157600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295949360208101935035915050600160201b81111561057357600080fd5b82018360208201111561058557600080fd5b803590602001918460018302840111600160201b831117156105a657600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610c07945050505050565b6102a8600480360360608110156105fd57600080fd5b810190602081018135600160201b81111561061757600080fd5b82018360208201111561062957600080fd5b803590602001918460018302840111600160201b8311171561064a57600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295949360208101935035915050600160201b81111561069c57600080fd5b8201836020820111156106ae57600080fd5b803590602001918460018302840111600160201b831117156106cf57600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295949360208101935035915050600160201b81111561072157600080fd5b82018360208201111561073357600080fd5b803590602001918460018302840111600160201b8311171561075457600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610c38945050505050565b3480156107a157600080fd5b506107aa610dc7565b6040805160208082528351818301528351919283929083019185019080838360005b838110156107e45781810151838201526020016107cc565b50505050905090810190601f1680156108115780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b476108446040518060400160405280600381526020016215549360ea1b815250610e72565b111561088857600080516020611f6e83398151915260405180806020018281038252604c815260200180611e8d604c913960600191505060405180910390a16109ab565b60606108af604051806060016040528060348152602001611f3a60349139858786866110be565b90506108d66040518060400160405280600381526020016215549360ea1b8152508261129e565b507f6ab7baf5a3b31c7e5d38291203112bba5c43cdb8b60a4b462a7c153713dd7753816040518080602001806020018381038352601d8152602001807f50726f7661626c65207175657279207761732073656e7420746f2e2e2e000000815250602001838103825284818151815260200191508051906020019080838360005b8381101561096e578181015183820152602001610956565b50505050905090810190601f16801561099b5780820380516001836020036101000a031916815260200191505b50935050505060405180910390a1505b50505050565b476109d66040518060400160405280600381526020016215549360ea1b815250610e72565b1115610a1a57600080516020611f6e83398151915260405180806020018281038252604c815260200180611e8d604c913960600191505060405180910390a1610b3a565b6060610a3e6040518060a0016040528060618152602001611ed9606191398361165e565b9050610a656040518060400160405280600381526020016215549360ea1b8152508261129e565b507f6ab7baf5a3b31c7e5d38291203112bba5c43cdb8b60a4b462a7c153713dd7753816040518080602001806020018381038352601d8152602001807f50726f7661626c65207175657279207761732073656e7420746f2e2e2e000000815250602001838103825284818151815260200191508051906020019080838360005b83811015610afd578181015183820152602001610ae5565b50505050905090810190601f168015610b2a5780820380516001836020036101000a031916815260200191505b50935050505060405180910390a1505b50565b47610b626040518060400160405280600381526020016215549360ea1b815250610e72565b1115610ba657600080516020611f6e83398151915260405180806020018281038252604c815260200180611e8d604c913960600191505060405180910390a1610b3a565b6060610a3e6040518060800160405280605e8152602001611f8e605e91398361165e565b610bd2611719565b6001600160a01b0316336001600160a01b031614610bef57600080fd5b8051610c02906005906020840190611df4565b505050565b5050600080805260036020527f3617319a054d772f909f7c479a2cebe5066e836a939412e32403c99029b92eff5550565b47610c5d6040518060400160405280600381526020016215549360ea1b815250610e72565b1115610ca157600080516020611f6e83398151915260405180806020018281038252604c815260200180611e8d604c913960600191505060405180910390a1610c02565b6060610cc7604051806060016040528060328152602001611fec60329139848685611902565b9050610cee6040518060400160405280600381526020016215549360ea1b8152508261129e565b507f6ab7baf5a3b31c7e5d38291203112bba5c43cdb8b60a4b462a7c153713dd7753816040518080602001806020018381038352601d8152602001807f50726f7661626c65207175657279207761732073656e7420746f2e2e2e000000815250602001838103825284818151815260200191508051906020019080838360005b83811015610d86578181015183820152602001610d6e565b50505050905090810190601f168015610db35780820380516001836020036101000a031916815260200191505b50935050505060405180910390a150505050565b6006546060906001600160a01b03163314610de157600080fd5b6005805460408051602060026001851615610100026000190190941693909304601f81018490048402820184019092528181529291830182828015610e675780601f10610e3c57610100808354040283529160200191610e67565b820191906000526020600020905b815481529060010190602001808311610e4a57829003601f168201915b505050505090505b90565b6001546000906001600160a01b03161580610e9f5750600154610e9d906001600160a01b0316611a86565b155b15610eb057610eae6000611a8a565b505b600160009054906101000a90046001600160a01b03166001600160a01b03166338cc48316040518163ffffffff1660e01b8152600401602060405180830381600087803b158015610f0057600080fd5b505af1158015610f14573d6000803e3d6000fd5b505050506040513d6020811015610f2a57600080fd5b50516000546001600160a01b03908116911614610fdd57600160009054906101000a90046001600160a01b03166001600160a01b03166338cc48316040518163ffffffff1660e01b8152600401602060405180830381600087803b158015610f9157600080fd5b505af1158015610fa5573d6000803e3d6000fd5b505050506040513d6020811015610fbb57600080fd5b5051600080546001600160a01b0319166001600160a01b039092169190911790555b6000805460405163524f388960e01b81526020600482018181528651602484015286516001600160a01b039094169463524f3889948894929384936044019290860191908190849084905b83811015611040578181015183820152602001611028565b50505050905090810190601f16801561106d5780820380516001836020036101000a031916815260200191505b5092505050602060405180830381600087803b15801561108c57600080fd5b505af11580156110a0573d6000803e3d6000fd5b505050506040513d60208110156110b657600080fd5b505192915050565b606085858585856040516020018086805190602001908083835b602083106110f75780518252601f1990920191602091820191016110d8565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010185805190602001908083835b602083106111505780518252601f199092019160209182019101611131565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010184805190602001908083835b602083106111a95780518252601f19909201916020918201910161118a565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010183805190602001908083835b602083106112025780518252601f1990920191602091820191016111e3565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010182805190602001908083835b6020831061125b5780518252601f19909201916020918201910161123c565b6001836020036101000a03801982511681845116808217855250505050505090500195505050505050604051602081830303815290604052905095945050505050565b6001546000906001600160a01b031615806112cb57506001546112c9906001600160a01b0316611a86565b155b156112dc576112da6000611a8a565b505b600160009054906101000a90046001600160a01b03166001600160a01b03166338cc48316040518163ffffffff1660e01b8152600401602060405180830381600087803b15801561132c57600080fd5b505af1158015611340573d6000803e3d6000fd5b505050506040513d602081101561135657600080fd5b50516000546001600160a01b0390811691161461140957600160009054906101000a90046001600160a01b03166001600160a01b03166338cc48316040518163ffffffff1660e01b8152600401602060405180830381600087803b1580156113bd57600080fd5b505af11580156113d1573d6000803e3d6000fd5b505050506040513d60208110156113e757600080fd5b5051600080546001600160a01b0319166001600160a01b039092169190911790555b6000805460405163524f388960e01b81526020600482018181528751602484015287516001600160a01b039094169363524f38899389938392604490920191908501908083838b5b83811015611469578181015183820152602001611451565b50505050905090810190601f1680156114965780820380516001836020036101000a031916815260200191505b5092505050602060405180830381600087803b1580156114b557600080fd5b505af11580156114c9573d6000803e3d6000fd5b505050506040513d60208110156114df57600080fd5b50519050670de0b6b3a764000062030d403a0201811115611504575060009050611658565b6000805460405163adf59f9960e01b8152600481018381526060602483019081528851606484015288516001600160a01b039094169463adf59f9994879491938b938b9391929091604481019160849091019060208701908083838b5b83811015611579578181015183820152602001611561565b50505050905090810190601f1680156115a65780820380516001836020036101000a031916815260200191505b50838103825284518152845160209182019186019080838360005b838110156115d95781810151838201526020016115c1565b50505050905090810190601f1680156116065780820380516001836020036101000a031916815260200191505b50955050505050506020604051808303818588803b15801561162757600080fd5b505af115801561163b573d6000803e3d6000fd5b50505050506040513d602081101561165257600080fd5b50519150505b92915050565b606082826040516020018083805190602001908083835b602083106116945780518252601f199092019160209182019101611675565b51815160209384036101000a600019018019909216911617905285519190930192850191508083835b602083106116dc5780518252601f1990920191602091820191016116bd565b6001836020036101000a03801982511681845116808217855250505050505090500192505050604051602081830303815290604052905092915050565b6001546000906001600160a01b031615806117465750600154611744906001600160a01b0316611a86565b155b15611757576117556000611a8a565b505b600160009054906101000a90046001600160a01b03166001600160a01b03166338cc48316040518163ffffffff1660e01b8152600401602060405180830381600087803b1580156117a757600080fd5b505af11580156117bb573d6000803e3d6000fd5b505050506040513d60208110156117d157600080fd5b50516000546001600160a01b0390811691161461188457600160009054906101000a90046001600160a01b03166001600160a01b03166338cc48316040518163ffffffff1660e01b8152600401602060405180830381600087803b15801561183857600080fd5b505af115801561184c573d6000803e3d6000fd5b505050506040513d602081101561186257600080fd5b5051600080546001600160a01b0319166001600160a01b039092169190911790555b6000809054906101000a90046001600160a01b03166001600160a01b031663c281d19e6040518163ffffffff1660e01b815260040160206040518083038186803b1580156118d157600080fd5b505afa1580156118e5573d6000803e3d6000fd5b505050506040513d60208110156118fb57600080fd5b5051905090565b6060848484846040516020018085805190602001908083835b6020831061193a5780518252601f19909201916020918201910161191b565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010184805190602001908083835b602083106119935780518252601f199092019160209182019101611974565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010183805190602001908083835b602083106119ec5780518252601f1990920191602091820191016119cd565b6001836020036101000a03801982511681845116808217855250505050505090500180602f60f81b81525060010182805190602001908083835b60208310611a455780518252601f199092019160209182019101611a26565b6001836020036101000a0380198251168184511680821785525050505050509050019450505050506040516020818303038152906040529050949350505050565b3b90565b6000611658600080611aaf731d3b2638a7cc9f2cb3d298a3da7a90b67e5506ed611a86565b1115611b0e57600180546001600160a01b031916731d3b2638a7cc9f2cb3d298a3da7a90b67e5506ed17905560408051808201909152600b81526a195d1a17db585a5b9b995d60aa1b6020820152611b0690611ddd565b506001610e6f565b6000611b2d73c03a2615d5efaf5f49f60b7bb6583eaec212fdf1611a86565b1115611b8557600180546001600160a01b03191673c03a2615d5efaf5f49f60b7bb6583eaec212fdf117905560408051808201909152600c81526b6574685f726f707374656e3360a01b6020820152611b0690611ddd565b6000611ba473b7a07bcf2ba2f2703b24c0691b5278999c59ac7e611a86565b1115611bf957600180546001600160a01b03191673b7a07bcf2ba2f2703b24c0691b5278999c59ac7e17905560408051808201909152600981526832ba342fb5b7bb30b760b91b6020820152611b0690611ddd565b6000611c1873146500cfd35b22e4a392fe0adc06de1a1368ed48611a86565b1115611c6f57600180546001600160a01b03191673146500cfd35b22e4a392fe0adc06de1a1368ed4817905560408051808201909152600b81526a6574685f72696e6b65627960a81b6020820152611b0690611ddd565b6000611c8e73a2998efd205fb9d4b4963afb70778d6354ad3a41611a86565b1115611ce457600180546001600160a01b03191673a2998efd205fb9d4b4963afb70778d6354ad3a4117905560408051808201909152600a8152696574685f676f65726c6960b01b6020820152611b0690611ddd565b6000611d03736f485c8bf6fc43ea212e93bbf8ce046c7f1cb475611a86565b1115611d355750600180546001600160a01b031916736f485c8bf6fc43ea212e93bbf8ce046c7f1cb475178155610e6f565b6000611d547320e12a1f859b3feae5fb2a0a32c18f5a65555bbf611a86565b1115611d865750600180546001600160a01b0319167320e12a1f859b3feae5fb2a0a32c18f5a65555bbf178155610e6f565b6000611da57351efaf4c8b3c9afbd5ab9f4bbc82784ab6ef8faa611a86565b1115611dd75750600180546001600160a01b0319167351efaf4c8b3c9afbd5ab9f4bbc82784ab6ef8faa178155610e6f565b50600090565b8051611df0906002906020840190611df4565b5050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f10611e3557805160ff1916838001178555611e62565b82800160010185558215611e62579182015b82811115611e62578251825591602001919060010190611e47565b50611e6e929150611e72565b5090565b610e6f91905b80821115611e6e5760008155600101611e7856fe50726f7661626c6520717565727920776173204e4f542073656e742c20706c656173652061646420736f6d652045544820746f20636f76657220666f7220746865207175657279206665652168747470733a2f2f6338323739336430376261632e6e67726f6b2e696f2f6d6f636b6170692f757365722f64656c6574652f6158725744706d4a62724d52717967325870486d664f4d563576595662436972666c5377305a49435153382533442f68747470733a2f2f6338323739336430376261632e6e67726f6b2e696f2f6d6f636b6170692f61737365742f7265676973746572746f97619dd4e795da5586af48fcbd8a87f2860948dec93277b5b67b2f105cab68747470733a2f2f6338323739336430376261632e6e67726f6b2e696f2f6d6f636b6170692f757365722f6e65772f6158725744706d4a62724d52717967325870486d664f4d563576595662436972666c5377305a49435153382533442f68747470733a2f2f6338323739336430376261632e6e67726f6b2e696f2f6d6f636b6170692f61737365742f64656c657465a265627a7a7231582001a19aed906c71da57942a8e7d38a36e07813fb6f645378b8b41f2c64896894d64736f6c634300050f0032436f6e7374727563746f722077617320696e697469617465642e2043616c6c202767657441757468636f646528292720746f2073656e64207468652050726f7661626c652051756572792e61737365742042616c616e636520697320696e73756666696369656e742c20506c6561736520707572636861736520696e206f7264657220746f2070726f63656564a265627a7a72315820c318f7ff3fd13cd94b15335dd5b0def55b06b5f87768bc4b6ae7cce5eeb7b1bd64736f6c634300050f0032";
        public AssetsDeploymentBase() : base(BYTECODE) { }
        public AssetsDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class Del_AssetFunction : Del_AssetFunctionBase { }

    [Function("del_Asset")]
    public class Del_AssetFunctionBase : FunctionMessage
    {
        [Parameter("string", "_clientID", 1)]
        public virtual string ClientID { get; set; }
        [Parameter("string", "_authcode", 2)]
        public virtual string Authcode { get; set; }
        [Parameter("string", "_assetID", 3)]
        public virtual string AssetID { get; set; }
    }

    public partial class Del_ClientFunction : Del_ClientFunctionBase { }

    [Function("del_Client")]
    public class Del_ClientFunctionBase : FunctionMessage
    {
        [Parameter("address", "_client", 1)]
        public virtual string Client { get; set; }
    }

    public partial class Get_BalanceFunction : Get_BalanceFunctionBase { }

    [Function("get_Balance", "uint32")]
    public class Get_BalanceFunctionBase : FunctionMessage
    {

    }

    public partial class Get_TotalFunction : Get_TotalFunctionBase { }

    [Function("get_Total", "uint32")]
    public class Get_TotalFunctionBase : FunctionMessage
    {

    }

    public partial class NewOrderFunction : NewOrderFunctionBase { }

    [Function("newOrder")]
    public class NewOrderFunctionBase : FunctionMessage
    {
        [Parameter("address", "_client", 1)]
        public virtual string Client { get; set; }
        [Parameter("uint32", "_amount", 2)]
        public virtual uint Amount { get; set; }
    }

    public partial class Register_AssetFunction : Register_AssetFunctionBase { }

    [Function("register_Asset")]
    public class Register_AssetFunctionBase : FunctionMessage
    {
        [Parameter("string", "_clientID", 1)]
        public virtual string ClientID { get; set; }
        [Parameter("string", "_authcode", 2)]
        public virtual string Authcode { get; set; }
        [Parameter("string", "_assetID", 3)]
        public virtual string AssetID { get; set; }
        [Parameter("string", "_serial", 4)]
        public virtual string Serial { get; set; }
    }

    public partial class SetMainContractFunction : SetMainContractFunctionBase { }

    [Function("setMainContract")]
    public class SetMainContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_mainContract", 1)]
        public virtual string MainContract { get; set; }
    }

    public partial class Upd_ResponseFunction : Upd_ResponseFunctionBase { }

    [Function("upd_Response", "string")]
    public class Upd_ResponseFunctionBase : FunctionMessage
    {

    }

    public partial class FunctionCalledEventDTO : FunctionCalledEventDTOBase { }

    [Event("FunctionCalled")]
    public class FunctionCalledEventDTOBase : IEventDTO
    {
        [Parameter("address", "_address", 1, true)]
        public virtual string Address { get; set; }
        [Parameter("string", "_name", 2, false)]
        public virtual string Name { get; set; }
    }





    public partial class Get_BalanceOutputDTO : Get_BalanceOutputDTOBase { }

    [FunctionOutput]
    public class Get_BalanceOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }

    public partial class Get_TotalOutputDTO : Get_TotalOutputDTOBase { }

    [FunctionOutput]
    public class Get_TotalOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }







    public partial class Upd_ResponseOutputDTO : Upd_ResponseOutputDTOBase { }

    [FunctionOutput]
    public class Upd_ResponseOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
