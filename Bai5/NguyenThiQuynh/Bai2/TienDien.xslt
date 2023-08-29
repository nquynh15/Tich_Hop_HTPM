<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
				<xsl:variable name="old" select="/goc/csd"/>
				<xsl:variable name="new" select="/goc/csc"/>
				<xsl:variable name="count" select="$new - $old"/>
				<xsl:choose>
					<xsl:when test =" $count &lt;= 100">
						<xsl:value-of select="3000 * $count"/>
					</xsl:when>
					<xsl:when test =" $count &lt;= 150">
						<xsl:value-of select="3000 * 100 + ($count - 100) * 4000"/>
					</xsl:when>
					<xsl:when test =" $count &lt;= 200">
						<xsl:value-of select="3000 * 100 + 50 * 4000 + ($count - 150) * 4500"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="3000 * 100 + 50 * 4000 + 50 * 4500 + ($count - 200)*5000"/>
					</xsl:otherwise>
				</xsl:choose>
				
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
