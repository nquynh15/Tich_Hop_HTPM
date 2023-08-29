<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="congty">
		<html>
			<head>
				<link rel="stylesheet" type="text/css" href="Bai1.css"/>
			</head>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG 11 - 2023</h1>
				<table>
					<xsl:for-each select="donvi">
						<h3>
							Mã đơn vị: <xsl:value-of select="@madv"/>
						</h3>
						<h3>
							Tên đơn vị: <xsl:value-of select="tendv"/>
						</h3>
						<h3>
							Điện thoại: <xsl:value-of select="dienthoai"/>
						</h3>

						<h2 align="center">DANH SÁCH NHÂN VIÊN</h2>
						<table border="1" width="90%" cellspacing="0">
							<tr class="tieude">
								<th>STT</th>
								<th>Mã NV</th>
								<th>HỌ TÊN</th>
								<th>NGÀY SINH</th>
								<th>HS LƯƠNG</th>
								<th>LƯƠNG</th>
							</tr>
							<xsl:for-each select="nhanvien[hsluong>=3]">
								<tr>
									<td class="so">
										<xsl:value-of select="position()"/>
									</td>
									<td class="chuoi">
										<xsl:value-of select="manv"/>
									</td>
									<td class="chuoi">
										<xsl:value-of select="hoten"/>
									</td>
									<td class="chuoi">
										<xsl:value-of select="ngaysinh"/>
									</td>
									<td class="so">
										<xsl:value-of select="hsluong"/>
									</td>
									<td class="so">
										<xsl:value-of select="hsluong * 730000"/>
									</td>
								</tr>
							</xsl:for-each>
						</table>
						<h2 align="right">THỦ TRƯỞNG ĐƠN VỊ</h2>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
