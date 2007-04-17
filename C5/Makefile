# ------------------------------------------------------------------------------
# Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
#
# Permission to use, copy, modify, and distribute this software for any
# purpose with or without fee is hereby granted, provided that the above
# copyright notice and this permission notice appear in all copies.
#
# THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
# WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
# MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
# ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
# WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
# ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
# OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
# ------------------------------------------------------------------------------

# NOTE:
# The above license applies to this file only.  Other files in the C5
# project are licensed as per the license in each file.


MODULES_use += dotnet.lib.project
MODULES_use += dotnet.csharp

SRCS_FIND_dir = $(PROJ_dir)/C5

# Not actually CLS-compliant as specified here
SRCS_FIND_exclude = %AssemblyInfo.cs

# Warning-ridden code, shut it up.
DOTNET_CS_warn = 0
DOTNET_CS_werror = 0


include $(MAKERY)/makery.mk

