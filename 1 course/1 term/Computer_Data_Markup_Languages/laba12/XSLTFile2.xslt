<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<title>Табель успеваемости студентов</title>
				<style>
			h1{
			margin: 0 0 20 200px;
			}
			table {
			border: 1px solid black;
			}
			tr:first-child {
			background-color: purple;
			}
			tr {
			background-color: pink;
			}
				</style>
			</head>
			<body>
				<h1>
					Табель успеваемости студентов
				</h1>
				<table>
					<tr>
						<th>Name</th>
						<th>Math</th>
						<th>Phys</th>
						<th>IT</th>
                    </tr>
					<xsl:for-each select="ALL/STUDENTS/STUDENT">
						<xsl:sort select="NAME" order="ascending"/>
						<tr>
							<td>
								<xsl:value-of select="NAME"/>
							</td>
								<xsl:choose>
								<!--<xsl:choose> используется вместе с элементами <xsl:when> и 
<xsl:otherwise>, чтобы определить проверку на выполнение условия-->
									<xsl:when test="MATH &gt; 8">
										<td bgcolor="green">
											<xsl:value-of select="MATH"/>
										</td>
									</xsl:when>
									<xsl:when test="MATH &lt; 4">
										<td bgcolor="red">
											<xsl:value-of select="MATH"/>
										</td>
									</xsl:when>
									<xsl:otherwise>
										<td bgcolor="yellow">
											<xsl:value-of select="MATH"/>
										</td>
									</xsl:otherwise>
								</xsl:choose>
							<xsl:choose>
								<xsl:when test="PHYS &gt; 8">
									<td bgcolor="green">
										<xsl:value-of select="PHYS"/>
									</td>
								</xsl:when>
								<xsl:when test="PHYS &lt; 4">
									<td bgcolor="red">
										<xsl:value-of select="PHYS"/>
									</td>
								</xsl:when>
								<xsl:otherwise>
									<td bgcolor="yellow">
										<xsl:value-of select="PHYS"/>
									</td>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="IT &gt; 8">
									<td bgcolor="green">
										<xsl:value-of select="IT"/>
									</td>
								</xsl:when>
								<xsl:when test="IT &lt; 4">
									<td bgcolor="red">
										<xsl:value-of select="IT"/>
									</td>
								</xsl:when>
								<xsl:otherwise>
									<td bgcolor="yellow">
										<xsl:value-of select="IT"/>
									</td>
								</xsl:otherwise>
							</xsl:choose>
						</tr>	
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>