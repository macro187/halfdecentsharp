# ------------------------------------------------------------------------------
# Copyright (c) 2007, 2008, 2009, 2010, 2011, 2012
# Ron MacNeil <macro@hotmail.com>
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


RESBIAN_PROJ_DESC := \
Name of the Resbian project
RESBIAN_PROJ := Halfdecent.Resbian
MAKERY_GLOBALS += RESBIAN_PROJ


# Get list of srcs for given culture
# $1 - culture
RESBIAN_GetFilesC = \
$(if $(filter .,$(1)),$(foreach f,$(RESBIAN_srcs),$(if $(findstring /,$(f)),,$(f))),$(filter $(1)/%,$(RESBIAN_srcs)))


# Get list of types for given culture
# $1 - culture
RESBIAN_GetTypes = \
$(sort $(foreach f,$(call RESBIAN_GetFilesC,$(1)),$(firstword $(subst __, ,$(notdir $(f))))))


# Get list of srcs for given culture and type
# $1 - culture
# $2 - type
RESBIAN_GetFilesCT = \
$(foreach f,$(call RESBIAN_GetFilesC,$(1)),$(if $(filter $(2)__%,$(notdir $(f))),$(call MAKE_EncodeWord,$(RESBIAN_srcdir))/$(f)))


# Generate outfile name for given culture and type
# $1 - culture
# $2 - type
RESBIAN_GetOutfile = \
$(RESBIAN_outdir)/$(DOTNET_namespace)$(if $(DOTNET_namespace),.)$(2).$(if $(filter .,$(1)),,$(1).)resources

