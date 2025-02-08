<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<title>Faculties of BSTU</title>
				<style>
					h1{
					margin: 0 0 20 200px;
					}
				</style>
			</head>
			
			<body>
				<h1>
					Faculties of BSTU
				</h1>
				<table border="1">
					<tr bgcolor="#C71585">
						<th>Name</th>
						<th>Department</th>
					</tr>
					<xsl:for-each select="ALL/SPECIALITIES/SPECIALITY">
						<xsl:sort select="NAME" order="ascending"/>
						<tr bgcolor="#FF69B4">
							<td>
								<xsl:value-of select="NAME"/>
							</td>
							<td>
								<xsl:value-of select="DEPARTMENT"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
