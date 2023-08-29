<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
		<xsl:variable name="so_1" select="/GOC/SO[1]"/>
		<xsl:variable name="so_2" select="/GOC/SO[2]"/>
			Số lớn nhất giữa hai số
		<xsl:value-of select="$so_1"/> và <xsl:value-of select="$so_2"/> là:
		<xsl:if test="$so_1 &gt; $so_2">
			<xsl:value-of select="$so_1"/>
		</xsl:if>
		<xsl:if test="$so_1 &lt;= $so_2">
			<xsl:value-of select="$so_2"/>
		</xsl:if></body>
		</html>
		
    </xsl:template>
</xsl:stylesheet>
