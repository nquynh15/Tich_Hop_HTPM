<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<h1 align="center"> BẢNG LƯƠNG THÁNG </h1>
		<xsl:for-each select="congty">
			<table border="1">
				<h3> Tên công ty: <xsl:value-of select="@tenCT"/> </h3>
				<h3> Tên phòng: <xsl:value-of select="tendv"/> </h3>
			</table>
		</xsl:for-each>
    </xsl:template>
	
</xsl:stylesheet>
