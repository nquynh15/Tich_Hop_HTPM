<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
				<xsl:variable name="so1" select="/GOC/SO[1]"/>
				<xsl:variable name="so2" select="/GOC/SO[2]"/>
				<b>Số lớn nhất giữa 2 số </b>
				<xsl:value-of select="$so1"/> và <xsl:value-of select="$so2"/> là
				
				<!--Cach 1-->
				<!--<xsl:if test="$so1 &gt;= $so2">
					<xsl:value-of select="$so1"/>
				</xsl:if>
				<xsl:if test="$so1 &lt; $so2">
					<xsl:value-of select="$so2"/>
				</xsl:if>-->
				
				<!--Cach 2-->
				<xsl:choose>
					<xsl:when test="$so1 &gt;= $so2">
						<xsl:value-of select="$so1"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="$so2"/>
					</xsl:otherwise>
				</xsl:choose>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
