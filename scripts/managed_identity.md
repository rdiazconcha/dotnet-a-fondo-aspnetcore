#PowerShell

$RG = "dotnet-a-fondo-aspnetcore"
$prefix = gh api repos/rdiazconcha/dotnet-a-fondo-aspnetcore/actions/oidc/customization/sub --jq .sub_claim_prefix

az identity create -g $RG -n id-dotnetafondoaspnetcore-github

$clientId = az identity show -g $RG -n id-dotnetafondoaspnetcore-github --query clientId -o tsv

$principalId = az identity show -g $RG -n id-dotnetafondoaspnetcore-github --query principalId -o tsv

az identity federated-credential create -g $RG --identity-name id-dotnetafondoaspnetcore-github -n github-main `
  --issuer https://token.actions.githubusercontent.com `
  --subject "${prefix}:ref:refs/heads/main" `
  --audiences api://AzureADTokenExchange

az role assignment create --assignee-object-id $principalId --assignee-principal-type ServicePrincipal `
  --role "Website Contributor" --scope (az group show -n $RG --query id -o tsv)

# En el repositorio del curso:

gh secret set AZURE_CLIENT_ID --body $clientId

gh secret set AZURE_TENANT_ID --body (az account show --query tenantId -o tsv)

gh secret set AZURE_SUBSCRIPTION_ID --body (az account show --query id -o tsv)