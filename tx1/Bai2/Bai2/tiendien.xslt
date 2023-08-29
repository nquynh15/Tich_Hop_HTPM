<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
				<xsl:variable name="socu" select="/SoDien/socu"/>
				<xsl:variable name="somoi" select="/SoDien/somoi"/>
				So cu: <xsl:value-of select="$socu"/> <br/>
				So moi: <xsl:value-of select="$somoi"/> <br/>
				<xsl:variable name="sodien" select="$somoi - $socu"/>
				Tien dien:
				<xsl:choose>
					<xsl:when test="$sodien &gt;=100">
						<xsl:value-of select="$sodien * 3000"/>
					</xsl:when>
					<xsl:when test="$sodien  &gt;=150">
						<xsl:value-of select="100 * 3000 + ($sodien - 100) * 4000"/>
					</xsl:when>
					<xsl:when test="$sodien  &gt;=200">
						<xsl:value-of select="100 * 3000 + 50 * 4000 + ($sodien - 150) * 4500"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="100 * 3000 + 50 * 4000 + 50 * 4500 + ($sodien - 200) * 5000"/>
					</xsl:otherwise>
				</xsl:choose>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
