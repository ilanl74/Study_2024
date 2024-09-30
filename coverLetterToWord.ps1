# Create a new Word application object
$word = New-Object -ComObject Word.Application
$word.Visible = $true

# Add a new document
$doc = $word.Documents.Add()

# Read the content of the .txt file
$txtContent = Get-Content -Path "C:\tmp\2024\Study_2024\coverLetter.txt"

# Write the content to the Word document
$selection = $word.Selection
$selection.TypeText($txtContent)

# Save the document
$doc.SaveAs([ref] "C:\tmp\2024\Study_2024\coverLetter.docx")

# Close the document and quit Word
$doc.Close()
$word.Quit()