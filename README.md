# Charity Application
![alt text](https://github.com/SaminMomin/CharityApplication/blob/master/Screenshots/Home%20Page.png)

# Introduction
This Charity application has been developed as a part of my final year project. It serves as a single platform for all the Charity organizations, NGOs and various other organizations working for a social cause to create fundraisers for their social cause and the prospective donors registered on the website can view and donate to the same.
<p>The donor can donate to any of the active causes registered by the organization on our website and similarly Organizations can register on our website and register any social cause, for which they need to raise the funds.</p>
<p> 
Now you might wonder what's new in that! Let me have the honour of introducing our primary technology behind this platform i.e <b>BLOCKCHAIN</b>
I have integrated Ethereum Smart Contract which also has been designed from scratch and deployed on the Ethereum test network.
</p>

#  Modules
## Donor
![alt text](https://github.com/SaminMomin/CharityApplication/blob/master/Screenshots/User%20Dashboard.png)

<p> The donor has access to the following functionalities:
<ul>
<li>View Organization</li>
<li>View Cause</li>
<li>Verify Own Identity on Ethereum Blockchain using Etherscan Explorer</li>
<li>View Donation History</li>
<li>Manage Profile</li>
</ul>
<br>
Whenever the donor registers on our website for the first time, his identity also gets registered on the Blockchain through the Ethereum Smart Contract function for registration of user consisting of his Name and Funds Donated till date which will be initialized to 0. 
After successful registration he/she can verify his/her own identity on the Blockchain after logging in to the website.
<br>
Donor can donate to any of the active cause and the donation will also get registered in the Smart Contract on Ethereum Blockchain. He/she can verify the same on Etherscan Explorer after it has been registered on Blockchain.

### Cause Donation Page
![alt text](https://github.com/SaminMomin/CharityApplication/blob/master/Screenshots/User%20Cause%20Donate.png)

</p>

## Organization
![alt text](https://github.com/SaminMomin/CharityApplication/blob/master/Screenshots/Organization%20Dashboard.png)

<p> The organization has access to the following functionalities:
<ul>
<li>Register Cause</li>
<li>View Cause</li>
<li>Verify Own Identity On Ethereum Blockchain Using Etherscan Explorer</li>
<li>View Received Donations For A Specific Cause</li>
<li>Manage Registered Causes</li>
<li>Manage Profile</li>
</ul>
<br>
Similar to the donor, an organization's identity also gets registered on the Blockchain when it registers for the first time on our website using similar functionality of Blockchain. Whenever an organization registers a cause, this event also gets recorded in the Smart Contract which consists fields mainly, <ul><li>Cause Name</li><li>Cause Goal</li><li>Associated Organization</li><li>Creation Time</li></ul>
<br>Organization can also view the received donations for a specific cause and can authenticate the same on Ethereum Blockchain via Etherscan explorer. It will display <ul><li>Donor's Name</li><li>Cause Name</li><li>Amount</li><li>Associated Organization</li><li>Donation Date</li></ul>
</p>

## Smart Contract
<p>The Smart contract has been designed by using Solidity language and it has been deployed on Ethereum's <b>Rinkeby Test Network</b> The Smart Contract currently contains following functionality embedded into it<ul><li>Registering User</li><li>Registering Organization</li><li>Registering Cause</li><li>Recording Donation</li><li>Get Donor</li><li>Get Organization</li></ul></p>
<p>The call to the Smart Contract has been established using the <b>Infura API</b> which enables to make the connection to Ethereum Network and fetch the Smart Contract from there.</p>

### A verified donation of our website on Etherscan Explorer.
![alt text](https://github.com/SaminMomin/CharityApplication/blob/master/Screenshots/User%20Donation%20Etherscan.png)

# Technologies Used:
## Blockchain
<ul><li>Ethereum</li></ul>

## FrontEnd:
<ul><li>HTML</li><li>CSS WITH BOOTSTRAP</li><li>JAVASCRIPT</li></ul>

## BackEnd:
<ul><li><a href='https://dotnet.microsoft.com/'>.NET Framework</a></li><li><a href='https://docs.soliditylang.org/en/v0.8.4/#'>SOLIDITY</a></li></ul>

## Libraries:
<ul><li><a href='https://nethereum.com/'>Nethereum</a></li></ul>

## Database:
<ul><li>Microsoft SQL Server</li></ul>

## APIs:
<ul><li><a href='https://infura.io/'>Infura</a></li></ul>

# Developer Contact
Feel free to connect with me on LinkedIn: <a href='https://www.linkedin.com/in/samin-momin-32a889145/'>Samin Momin</a>
