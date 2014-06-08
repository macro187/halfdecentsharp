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


# Require the Resbian program
#
PROJ_required += $(RESBIAN_PROJ)


RESBIAN_srcdir_DESC ?= \
Resource source directory, absolute
$(call PROJ_DeclareVar,RESBIAN_srcdir)
RESBIAN_srcdir_DEFAULT = $(PROJ_dir)/res


RESBIAN_srcs_DESC ?= \
Resource source files (relative to source dir) (list)
$(call PROJ_DeclareVar,RESBIAN_srcs)
RESBIAN_srcs_DEFAULT = \
$(call MAKE_Shell,\
test -d $(call SYSTEM_ShellEscape,$(RESBIAN_srcdir)) \
&& cd $(call SYSTEM_ShellEscape,$(RESBIAN_srcdir)) \
&& find * -maxdepth 1 -type f \
| $(SYSTEM_SHELL_CLEANPATH) \
| $(SYSTEM_SHELL_ENCODEWORD) \
)


RESBIAN_srcs_abs_DESC ?= \
(read-only) Resource source files (absolute) (list)
$(call PROJ_DeclareVar,RESBIAN_srcs_abs)
RESBIAN_srcs_abs = \
$(foreach src,$(RESBIAN_srcs),$(call MAKE_EncodeWord,$(RESBIAN_srcdir))/$(src))


RESBIAN_cultures_DESC ?= \
(read-only) Cultures for which resource sources exist (. = neutral) (list)
$(call PROJ_DeclareVar,RESBIAN_cultures)
RESBIAN_cultures = \
$(sort $(call MAKE_PathParentName,$(RESBIAN_srcs)))


RESBIAN_dotfile_DESC ?= \
(read-only) Dotfile representing the resbian output files
$(call PROJ_DeclareVar,RESBIAN_dotfile)
RESBIAN_dotfile = $(OUT_dir)/_resbian


RESBIAN_outfiles_DESC ?= \
(read-only) Output .resources files (list)
$(call PROJ_DeclareVar,RESBIAN_outfiles)
RESBIAN_outfiles = \
$(foreach c,$(RESBIAN_cultures),$(foreach t,$(call RESBIAN_GetTypes,$(c)),$(call MAKE_EncodeWord,$(call RESBIAN_GetOutfile,$(c),$(t)))))

# Add Resbian outfiles to DOTNET_resources for embedding into the dotnet binary
#
DOTNET_resources += $(RESBIAN_outfiles)

