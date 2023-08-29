<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
				<xsl:variable name="a" select="/goc/hsa"/>
				<xsl:variable name="b" select="/goc/hsb"/>
				Phương trình: <xsl:value-of select="$a"/> x+ <xsl:value-of select="$b"/> = 0
				<xsl:choose>
					<xsl:when test="$a=0">
						Phương tình vô nghiệm!
					</xsl:when>
					<xsl:when test="$b=0">
						Phương tình vô số nghiệm!
					</xsl:when>
					<xsl:otherwise>
						Phương trình có nghiệm là:
						<xsl:value-of select="-$b div $a"/>
					</xsl:otherwise>
				</xsl:choose>
				

				<!--<xsl:if test="$a = 0">
					Phương tình vô nghiệm!
				</xsl:if>
				<xsl:if test="$b = 0">
					Phương tình vô số nghiệm!
				</xsl:if>
					Phương trình có nghiệm là:
				<xsl:value-of select="-$b div $a"/>-->
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
